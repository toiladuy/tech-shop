using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class Search : Controller
    {
        private readonly PhTechContext _context;

        public Search(PhTechContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SearchByName(string? id)
        {
            var user = HttpContext.Session.GetString("user");
            Double? min = 0;
            Double? max = 0;

            FillCartData();

            if (id == null)
            {
                String search = "";
                try
                {
                    search = HttpContext.Request.Form["searchname"];
                    if (search != null)
                    {
                        ViewData["ProductBrand"] = _context.Brands;
                        ViewData["ProductSize"] = _context.Sizes;
                        ViewData["ProductType"] = _context.Types;
                        ViewData["ProductColor"] = _context.Colors;
                        var phContext = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.ProductName.Contains(search));
                        min = phContext.Select(x => x.OutPrice)?.Min();
                        max = phContext.Select(x => x.OutPrice)?.Max();
                        ViewData["min"] = min;
                        ViewData["max"] = max;
                        return View(await phContext.ToListAsync());
                    }
                    else
                    {
                        String price = HttpContext.Request.Form["pricesearch"];
                        Debug.WriteLine("long" + price.Trim());
                        string[] a = price.Trim().Split('$');
                        String[] b = a[1].Trim().Split('-');
                        Debug.WriteLine(b[0].Trim() + a[2]);
                        ViewData["ProductBrand"] = _context.Brands;
                        ViewData["ProductSize"] = _context.Sizes;
                        ViewData["ProductType"] = _context.Types;
                        ViewData["ProductColor"] = _context.Colors;
                        var phContext = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.OutPrice >= Convert.ToDouble(b[0].Trim()) && x.OutPrice <= Convert.ToDouble(a[2].Trim()));
                        min = phContext.Select(x => x.OutPrice)?.Min();
                        max = phContext.Select(x => x.OutPrice)?.Max();
                        ViewData["min"] = min;
                        ViewData["max"] = max;
                        return View(await phContext.ToListAsync());
                    }
                }
                catch
                {

                }

                return Redirect("/Products");

            }
            else
            {
                string[] arrListStr = id.Split(' ');
                if (arrListStr[1].Equals("type"))
                {
                    ViewData["ProductBrand"] = _context.Brands;
                    ViewData["ProductSize"] = _context.Sizes;
                    ViewData["ProductType"] = _context.Types;
                    ViewData["ProductColor"] = _context.Colors;
                    var phContext = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.ProductTypeNavigation.Id.Equals(Int32.Parse(arrListStr[0])));
                    min = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Min();
                    max = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Max();
                    ViewData["min"] = min;
                    ViewData["max"] = max;
                    return View(await phContext.ToListAsync());
                }
                else if (arrListStr[1].Equals("brand"))
                {
                    ViewData["ProductBrand"] = _context.Brands;
                    ViewData["ProductSize"] = _context.Sizes;
                    ViewData["ProductType"] = _context.Types;
                    ViewData["ProductColor"] = _context.Colors;
                    var phContext = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.ProductBrandNavigation.Id.Equals(Int32.Parse(arrListStr[0])));
                    min = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Min();
                    max = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Max();
                    ViewData["min"] = min;
                    ViewData["max"] = max;
                    return View(await phContext.ToListAsync());
                }
                else if (arrListStr[1].Equals("size"))
                {
                    ViewData["ProductBrand"] = _context.Brands;
                    ViewData["ProductSize"] = _context.Sizes;
                    ViewData["ProductType"] = _context.Types;
                    ViewData["ProductColor"] = _context.Colors;
                    var phContext = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.ProductSizeNavigation.Id.Equals(Int32.Parse(arrListStr[0])));
                    min = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Min();
                    max = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Max();
                    ViewData["min"] = min;
                    ViewData["max"] = max;
                    return View(await phContext.ToListAsync());
                }
                else
                {
                    ViewData["ProductBrand"] = _context.Brands;
                    ViewData["ProductSize"] = _context.Sizes;
                    ViewData["ProductType"] = _context.Types;
                    ViewData["ProductColor"] = _context.Colors;
                    var phContext = _context.Products.Include(p => p.ProductBrandNavigation).Include(p => p.ProductSizeNavigation).Include(p => p.ProductTypeNavigation).Where(x => x.ProductColorNavigation.Id.Equals(Int32.Parse(arrListStr[0])));
                    min = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Min();
                    max = phContext.Select(x => x.OutPrice).DefaultIfEmpty().Max();
                    ViewData["min"] = min;
                    ViewData["max"] = max;
                    return View(await phContext.ToListAsync());
                }
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
    }
}
