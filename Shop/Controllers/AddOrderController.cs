using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Shop.Models;
using Shop.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class AddOrderController : Controller
    {
        private readonly PhTechContext _context;

        public AddOrderController(PhTechContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        private void FillCartData()
        {
            var user = HttpContext.Session.GetString("user");
            if (user == null)
            {
                ViewData["cartItems"] = null;
            }
            else
            {
                var orderCtx = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
                var checkOrder = orderCtx.Where(s => s.UserId.Equals(int.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
                if (checkOrder == null)
                {
                    ViewData["cartItems"] = null;
                }
                else
                {
                    ViewData["cartItems"] = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(s => s.OrderId == checkOrder.Id);
                }
            }
        }

        public IActionResult AddtoCart(int? id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == null)
            {
                return Redirect("/Login");
            }

            if (id == null)
            {
                return Redirect("/Home");
            }

            var product = _context.Products
                .Include(p => p.ProductBrandNavigation)
                .Include(p => p.ProductSizeNavigation)
                .Include(p => p.ProductTypeNavigation)
                .Where(x => x.Id.Equals(id));

            if (product.FirstOrDefault().ProductQuantity <= 0)
            {
                TempData["AlertType"] = "alert-success";
                TempData["AlertMessage"] = "Product is sold out";
                return Redirect("/Products");
            }

            var orderCtx = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
            var openOrder = orderCtx.Where(s => s.UserId.Equals(int.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
            if (openOrder != null)
            {
                var orderDetailsCtx = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
                var checkProductExist = orderDetailsCtx.Where(s => s.ProductId.Equals(id) && s.OrderId.Equals(openOrder.Id));
                var orderder = orderDetailsCtx.Where(x => x.OrderId.Equals(openOrder.Id));
                if (checkProductExist.Count() > 0)
                {
                    if (product.FirstOrDefault().ProductQuantity - (checkProductExist.FirstOrDefault().Quantity + 1) < 0)
                    {
                        TempData["AlertType"] = "alert-success";
                        TempData["AlertMessage"] = "Product is sold out";
                        return Redirect("/Products");
                    }

                    var orderDetalis = checkProductExist.FirstOrDefault();
                    orderDetalis.Quantity++;
                    _context.OrderDetails.Update(orderDetalis);
                    _context.SaveChanges();

                    double totalPrice = 0;
                    foreach (OrderDetail ordetail in orderder)
                    {
                        totalPrice += Convert.ToDouble(ordetail.Quantity * ordetail.Price);
                        Debug.WriteLine(totalPrice + "gia");
                    }

                    openOrder.TotalPrice = totalPrice;
                    _context.Orders.Update(openOrder);
                    _context.SaveChanges();
                }
                else
                {
                    double price = _context.Products.Where(x => x.Id.Equals(id)).FirstOrDefault().OutPrice;
                    OrderDetail orderDetail = new()
                    {
                        OrderId = openOrder.Id,
                        ProductId = id,
                        Price = price,
                        Quantity = 1
                    };
                    _context.OrderDetails.Add(orderDetail);
                    _context.SaveChanges();

                    double totalPrice = 0;
                    foreach (OrderDetail ordetail in orderder)
                    {
                        totalPrice += Convert.ToDouble(ordetail.Quantity * ordetail.Price);
                        Debug.WriteLine(totalPrice);
                    }
                    openOrder.TotalPrice = totalPrice;
                    _context.Orders.Update(openOrder);
                    _context.SaveChanges();
                }
                TempData["AlertType"] = "alert-success";
                TempData["AlertMessage"] = "Add To Cart successful";
                return Redirect("/Products");
            }
            else
            {
                double price = _context.Products.Where(x => x.Id.Equals(id)).FirstOrDefault().OutPrice;

                Order order = new()
                {
                    CreateAt = DateTime.Now,
                    OrderId = GenerateOrderID(6),
                    TotalPrice = price,
                    Status = OrderStatus.New,
                    UserId = int.Parse(user),
                    PaymentMethod = Payment.Method.COD.ToString(),
                    PaymentStatus = (int?)Payment.Status.UNPAID
                };
                _context.Orders.Add(order);
                _context.SaveChanges();

                OrderDetail orderDetail = new()
                {
                    OrderId = order.Id,
                    ProductId = id,
                    Price = price,
                    Quantity = 1
                };
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();

                TempData["AlertType"] = "alert-success";
                TempData["AlertMessage"] = "Add To Cart successful";
                return Redirect("/Products");
            }
        }

        public IActionResult Indexcheckout()
        {
            var userId = HttpContext.Session.GetString("user");
            if (userId == null)
            {
                return Redirect("/Login");
            }
            var uid = int.Parse(userId);
            var user = _context.Users.FirstOrDefault(u => u.Id.Equals(uid));
            if (user == null || user.Status == 0)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "Your account has not been activated yet.";
                return Redirect("/Login/CheckActivation");
            }

            var orderCtx = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
            var checkOrder = orderCtx.Where(s => s.UserId.Equals(Int32.Parse(userId)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
            if (checkOrder == null)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "Cart is empty.";
                return Redirect("/Home");
            }

            FillCartData();

            ViewData["Order"] = checkOrder;
            ViewData["User"] = _context.Users.Include(u => u.Role).Where(x => x.Id.Equals(Int32.Parse(userId)));
            ViewData["Product"] = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation);
            ViewData["Voucher"] = _context.Vouchers;
            var detailsCtx = _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Where(s => s.OrderId == checkOrder.Id);
            return View(detailsCtx.ToList());
        }

        [HttpPost]
        public ActionResult PlaceCOD()
        {
            var user = HttpContext.Session.GetString("user");
            if (user == null)
            {
                return Redirect("/Login");
            }
            var checkOrder = _context.Orders.Where(s => s.UserId.Equals(int.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
            checkOrder.Note = HttpContext.Request.Form["ordernote"];
            checkOrder.PaymentMethod = Payment.Method.COD.ToString();
            _context.Orders.Update(checkOrder);
            _context.SaveChanges();
            return Redirect("PaymentComplete");
        }

        [HttpPost]
        public async Task<ActionResult> PayViaZaloPay()
        {
            var user = HttpContext.Session.GetString("user");
            if (user == null)
            {
                return Redirect("/Login");
            }
            var checkOrder = _context.Orders.Include(o => o.User).Include(o => o.Voucher)
                .Where(s => s.UserId.Equals(int.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
            var ordetail = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(s => s.OrderId == checkOrder.Id).ToArray();
            var finalPrice = CalculateTotalOrder(checkOrder, ordetail);
            string redirectUrl = "https://localhost:44398/AddOrder/PaymentComplete";
            string callbackUrl = "https://localhost:44398/AddOrder/PaymentCallback";
            var postbackData = new Dictionary<string, string> {
                { "orderId", checkOrder.Id.ToString() },
                { "orderNumber", checkOrder.OrderId }
            };
            var resp = await ZaloPayService.CreateOrder(checkOrder.OrderId, finalPrice, redirectUrl, callbackUrl, postbackData);

            checkOrder.PaymentMethod = Payment.Method.ZALOPAY.ToString();
            checkOrder.PaymentDetail = resp.Item1;
            _context.Orders.Update(checkOrder);
            _context.SaveChanges();

            return Redirect(resp.Item2);
        }

        [HttpGet]
        public async Task<IActionResult> PaymentComplete([FromQuery(Name = "apptransid")] string appTransId)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == null) return Redirect("/Login");

            var checkOrder = _context.Orders.Include(o => o.User).Include(o => o.Voucher)
                .Where(s => s.UserId.Equals(int.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
            if (checkOrder == null)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "Cart is empty";
                return Redirect("/Home");
            }
            ViewData["Order"] = checkOrder;
            ViewData["OrderNumber"] = checkOrder.OrderId;
            ViewData["User"] = _context.Users.Include(u => u.Role).First(x => x.Id.Equals(Int32.Parse(user)));
            ViewData["Product"] = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation);
            ViewData["Voucher"] = _context.Vouchers;

            FillCartData();

            var orderDetails = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(s => s.OrderId == checkOrder.Id).ToList();

            if (!string.IsNullOrEmpty(appTransId))
            {
                ViewData["IsCOD"] = false;
                var paymentSuccess = await ZaloPayService.IsOrderSuccess(appTransId);
                if (paymentSuccess)
                {
                    checkOrder.PaymentStatus = (int)Payment.Status.PAID;
                    _context.Orders.Update(checkOrder);
                    _context.SaveChanges();

                    ViewData["IsPaymentSuccess"] = true;
                    AfterCheckoutDone();
                    return View(orderDetails);
                }
                else
                {
                    checkOrder.PaymentStatus = (int)Payment.Status.FAILED;
                    _context.Orders.Update(checkOrder);
                    _context.SaveChanges();

                    ViewData["IsPaymentSuccess"] = false;
                    return View();
                }
            }
            else
            {
                // COD
                ViewData["IsPaymentSuccess"] = true;
                ViewData["IsCOD"] = true;
                AfterCheckoutDone();
                return View(orderDetails);
            }
        }

        private void AfterCheckoutDone()
        {
            var user = HttpContext.Session.GetString("user");

            var checkOrder = _context.Orders.Where(s => s.UserId.Equals(int.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
            checkOrder.Status = OrderStatus.WaitingForConfirm;
            _context.Orders.Update(checkOrder);
            _context.SaveChanges();

            var orderDetails = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(s => s.OrderId == checkOrder.Id).ToArray();
            foreach (OrderDetail orderDetail in orderDetails)
            {
                var product = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation)
                    .Include(p => p.ProductTypeNavigation).Where(x => x.Id.Equals(orderDetail.ProductId));
                product.FirstOrDefault().ProductQuantity = Convert.ToInt32(product.FirstOrDefault().ProductQuantity - orderDetail.Quantity);
                _context.Products.Update(product.FirstOrDefault());
                _context.SaveChanges();
            }

            try
            {
                if (checkOrder.VoucherId != null)
                {
                    var voucher = _context.Vouchers.Where(x => x.Id.Equals(checkOrder.VoucherId)).FirstOrDefault();
                    if (voucher != null)
                    {
                        voucher.Quantity--;
                        _context.Vouchers.Update(voucher);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult PayViaMomo()
        {
            var user = HttpContext.Session.GetString("user");
            var checkOrder = _context.Orders.Include(o => o.User).Include(o => o.Voucher)
                .Where(s => s.UserId.Equals(Int32.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
            var ordetail = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(s => s.OrderId == checkOrder.Id).ToArray();
            var finalPrice = CalculateTotalOrder(checkOrder, ordetail);

            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
            string partnerCode = "MOMO";
            string accessKey = "F8BBA842ECF85";
            string serectkey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";
            string orderInfo = "Thanh Toán Mua Hàng PH-Tech";
            string redirectUrl = "https://localhost:44398/AddOrder/Indexcheckout";
            string ipnUrl = "https://localhost:44398/AddOrder/Indexcheckout";
            string requestType = "captureWallet";
            double amount = finalPrice;
            string orderId = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            string rawHash = "accessKey=" + accessKey +
                  "&amount=" + amount +
                  "&extraData=" + extraData +
                  "&ipnUrl=" + ipnUrl +
                  "&orderId=" + orderId +
                  "&orderInfo=" + orderInfo +
                  "&partnerCode=" + partnerCode +
                  "&redirectUrl=" + redirectUrl +
                  "&requestId=" + requestId +
                  "&requestType=" + requestType
                  ;
            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", "en" },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        private Double CalculateTotalOrder(Order order, OrderDetail[] orderDetails)
        {
            double total = 0;
            double sale = 0;
            foreach (var item in orderDetails)
            {
                total += Convert.ToDouble(item.Quantity * item.Price);
                if (order.VoucherId != null)
                {
                    var voucher = _context.Vouchers.First(v => v.Id == order.VoucherId);
                    sale = Convert.ToDouble(voucher.VoucherDiscount);
                }
            }
            var subtotal = total * sale / 100;
            return total - subtotal;
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public ActionResult ConfirmPaymentClient()
        {
            //hiển thị thông báo cho người dùng
            return View();
        }

        public ActionResult SavePayment(float total)
        {
            //string url = Request.Url.PathAndQuery;
            string url = HttpContext.Request.Host.ToString();
            if (!url.Contains("message=Success"))
            {
                return RedirectToAction("Index");
            }
            else
            {
                PlaceCOD();
            }
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            var orderDetail = _context.OrderDetails.Where(x => x.Id == id).FirstOrDefault();
            var ProductID = orderDetail.ProductId;
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
            var product = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.Id.Equals(ProductID));
            var user = HttpContext.Session.GetString("user");
            var phContext = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
            var checkOrderExist = phContext.Where(s => s.UserId.Equals(Int32.Parse(user)) && s.Status.Equals(OrderStatus.New));
            var data = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            var orderder = data.Where(x => x.OrderId.Equals(checkOrderExist.FirstOrDefault().Id));
            double totlaprice = 0;
            foreach (OrderDetail ordetail in orderder)
            {
                totlaprice += Convert.ToDouble(ordetail.Quantity * ordetail.Price);
                Debug.WriteLine(totlaprice + "gia");
            }

            checkOrderExist.FirstOrDefault().TotalPrice = totlaprice;
            _context.Orders.Update(checkOrderExist.FirstOrDefault());
            _context.SaveChanges();

            return Redirect("/OrderDetails");
        }
        public IActionResult AddQuantity(int? id)
        {
            var orderDetail = _context.OrderDetails.Where(x => x.Id == id).FirstOrDefault();
            orderDetail.Quantity = orderDetail.Quantity + 1;
            var ProductID = orderDetail.ProductId;
            _context.OrderDetails.Update(orderDetail);
            _context.SaveChanges();
            var product = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.Id.Equals(ProductID));
            var user = HttpContext.Session.GetString("user");
            var phContext = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
            var checkOrderExist = phContext.Where(s => s.UserId.Equals(Int32.Parse(user)) && s.Status.Equals(OrderStatus.New));
            var data = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            var orderder = data.Where(x => x.OrderId.Equals(checkOrderExist.FirstOrDefault().Id));
            double totlaprice = 0;
            foreach (OrderDetail ordetail in orderder)
            {
                totlaprice += Convert.ToDouble(ordetail.Quantity * ordetail.Price);
                Debug.WriteLine(totlaprice + "gia");
            }

            checkOrderExist.FirstOrDefault().TotalPrice = totlaprice;
            _context.Orders.Update(checkOrderExist.FirstOrDefault());
            _context.SaveChanges();

            return Redirect("/OrderDetails");
        }
        public IActionResult SubQuantity(int? id)
        {
            var orderDetail = _context.OrderDetails.Where(x => x.Id == id).FirstOrDefault();
            if (orderDetail.Quantity <= 1)
            {
                return Redirect("/OrderDetails");
            }
            else
            {
                orderDetail.Quantity = orderDetail.Quantity - 1;
                var ProductID = orderDetail.ProductId;
                _context.OrderDetails.Update(orderDetail);
                _context.SaveChanges();
                var product = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.Id.Equals(ProductID));
                var user = HttpContext.Session.GetString("user");
                var phContext = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
                var checkOrderExist = phContext.Where(s => s.UserId.Equals(Int32.Parse(user)) && s.Status.Equals(OrderStatus.New));
                var data = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
                var orderder = data.Where(x => x.OrderId.Equals(checkOrderExist.FirstOrDefault().Id));
                double totlaprice = 0;
                foreach (OrderDetail ordetail in orderder)
                {
                    totlaprice += Convert.ToDouble(ordetail.Quantity * ordetail.Price);
                    Debug.WriteLine(totlaprice + "gia");
                }

                checkOrderExist.FirstOrDefault().TotalPrice = totlaprice;
                _context.Orders.Update(checkOrderExist.FirstOrDefault());
                _context.SaveChanges();

                return Redirect("/OrderDetails");
            }
        }
        public IActionResult Voucher()
        {
            double? percent = 0;

            String voucher = HttpContext.Request.Form["vouchercode"];
            var user = HttpContext.Session.GetString("user");
            var date = _context.Vouchers.Where(x => x.VoucherCode.Equals(voucher)).FirstOrDefault().DeleteAt;
            var quanlity = _context.Vouchers.Where(x => x.VoucherCode.Equals(voucher)).FirstOrDefault().Quantity;
            Debug.WriteLine(date);
            if (!date.ToString().Equals("") || quanlity == 0)
            {
                TempData["AlertType"] = "alert-success";
                TempData["AlertMessage"] = "Expired Voucher ";
                return Redirect("/OrderDetails");
            }
            percent = _context.Vouchers.Where(x => x.VoucherCode.Equals(voucher)).FirstOrDefault()?.VoucherDiscount;
            var phContext = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
            var checkOrderExist = phContext.Where(s => s.UserId.Equals(Int32.Parse(user)) && s.Status.Equals(OrderStatus.New));
            checkOrderExist.FirstOrDefault().TotalPrice = (checkOrderExist.FirstOrDefault().TotalPrice) - Convert.ToDouble(checkOrderExist.FirstOrDefault().TotalPrice * (percent / 100));
            checkOrderExist.FirstOrDefault().VoucherId = _context.Vouchers.Where(x => x.VoucherCode.EndsWith(voucher)).FirstOrDefault().Id;
            _context.Orders.Update(checkOrderExist.FirstOrDefault());
            _context.SaveChanges();

            return Redirect("/OrderDetails");
        }

        public IActionResult AddtoWishlist(int? id)
        {
            var user = HttpContext.Session.GetString("user");
            var product = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation)
                .Include(p => p.ProductTypeNavigation).Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (user == null)
            {
                return Redirect("/Login");
            }

            if (product == null)
            {
                TempData["AlertType"] = "alert-success";
                TempData["AlertMessage"] = "Product not found";
                return Redirect("/Products");
            }

            var wishlistExist = _context.Wishlists.Any(w => w.UserId == int.Parse(user) && w.ProductId == id);
            if (!wishlistExist)
            {
                Wishlist wl = new Wishlist();
                wl.UserId = int.Parse(user);
                wl.ProductId = id;
                wl.CreateAt = DateTime.Now;
                _context.Wishlists.Add(wl);
                _context.SaveChanges();
            }

            TempData["AlertType"] = "alert-success";
            TempData["AlertMessage"] = "Add To Wish List successful";
            return Redirect("/Products");
        }

        public static string GenerateOrderID(int Length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, Length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
