using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataFashionContext _context;
        public HomeController(ILogger<HomeController> logger, DataFashionContext context)
        {
            _logger = logger;
            _context = context;
        }
      
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("user");
            int? checkOrderID = 0;
            ViewData["allorderdetail"] = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            if (user == null)
            {   
                ViewData["orderdeatail"] = null;
              
                return View();
            }
            else
            {
                ViewData["orderdeatail"] = null;
                try
                {
                    var dataFashionContext1 = _context.Orders.Include(o => o.User).Include(o => o.Voucher);
                     checkOrderID = dataFashionContext1.Where(s => s.UserId.Equals(Int32.Parse(user)) && s.Status.Equals(1)).FirstOrDefault()?.Id;
                    if(checkOrderID == 0)
                    {
                        ViewData["orderdeatail"] = null;
                        return View();
                    }
                    else
                    {
                        ViewData["orderdeatail"] = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(s => s.OrderId == checkOrderID); 
                        return View();
                    }
                  
                }
                catch(Exception e)
                {
                    ViewData["orderdeatail"] = null;
                    return View();
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
