using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly PhTechContext _context;

        public OrderDetailsController(PhTechContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                ViewData["Voucher"] = _context.Vouchers;

                var orderCtx = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
                var checkOrder = orderCtx.Where(s => s.UserId.Equals(Int32.Parse(user)) && s.Status.Equals(OrderStatus.New)).FirstOrDefault();
                ViewData["Order"] = checkOrder;

                var orderDetailsCtx = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
                if (checkOrder == null)
                {
                    return View(await orderDetailsCtx.ToListAsync());
                }
                return View(await orderDetailsCtx.Where(s => s.OrderId == checkOrder.Id).ToListAsync());

            }
            else
            {
                return Redirect("/Login");
            }

        }

        public async Task<IActionResult> Wishlist()
        {
            var user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                FillCartData();
                var wishlistCtx = _context.Wishlists.Include(o => o.Product).Where(w => w.UserId == int.Parse(user));
                return View(await wishlistCtx.ToListAsync());
            }
            else
            {
                return Redirect("/Login");
            }
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

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductCode");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,OrderId,Quantity,Price")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductCode", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductCode", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,OrderId,Quantity,Price")] OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductCode", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
