using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhTechContext _context;

        public HomeController(PhTechContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            FillCartData();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
