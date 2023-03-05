using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin.Models;
using AdminWeb.Command;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Admin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PhTechContext _context;
        CheckPermission check = new CheckPermission();
        public OrdersController(PhTechContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "VIEW_ORDERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            {
             var phContext = _context.Orders.Include(o => o.User).Include(o => o.Voucher).Where(x => x.Status >=2  && x.Status < 5);
            return View(await phContext.ToListAsync());
            }
           
        }
        public async Task<IActionResult> IndexHoadon()
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "VIEW_ORDERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            {
                var phContext = _context.Orders.Include(o => o.User).Include(o => o.Voucher).Where(x => x.Status == 5);
                return View(await phContext.ToListAsync());
            }

        }
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "DETAILS_ORDERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            if (id == null)
            {
                return NotFound();
            }

            var phContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(s => s.OrderId == id);
            return View(await phContext.ToListAsync());
          
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "CREATE_ORDERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            {
                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
                ViewData["VoucherId"] = new SelectList(_context.Vouchers, "Id", "Id");
                return View();
            }
               
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,UserId,TotalPrice,CreateAt,VoucherId,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", order.UserId);
            ViewData["VoucherId"] = new SelectList(_context.Vouchers, "Id", "Id", order.VoucherId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public  IActionResult Edit(int? id)
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "EDIT_ORDERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders.Where(x => x.Id.Equals(id)).FirstOrDefault();
            order.Status = order.Status + 1;
            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,UserId,TotalPrice,CreateAt,VoucherId,Status")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", order.UserId);
            ViewData["VoucherId"] = new SelectList(_context.Vouchers, "Id", "Id", order.VoucherId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "DELETE_ORDERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Voucher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {  
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
