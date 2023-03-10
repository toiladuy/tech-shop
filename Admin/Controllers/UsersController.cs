using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin.Models;
using AdminWeb.SendMail;
using AdminWeb.Command;
using Microsoft.AspNetCore.Http;

namespace Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly PhTechContext _context;
        CheckPermission check = new CheckPermission();
        public UsersController(PhTechContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var role = HttpContext.Session.GetString("role");
            var user1 = HttpContext.Session.GetString("user");
            if (check.HasCredential(role, "VIEW_USERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            {
            var phContext = _context.Users.Include(u => u.Role);
                TempData["checkuser"] = user1;
                return View(await phContext.ToListAsync());
            }
               
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "DETAILS_USERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
           if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "CREATE_USERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
            {
                ViewData["Password"] = GeneratePassword(8);
                ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            return View();
            }
              
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,Fullname,Phone,Address,Status,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Count(u => u.Email.Equals(user.Email)) > 0)
                {
                    return Redirect("/Users");
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                String from = "ititiu17081@hcmiu.edu.vn";
                String passord = "";
                MailUtils.SendMailGoogleSmtp(from, user.Email, "Password Dành Cho Nhân Viên ", "Password: " + user.Password + " Vui Lòng không chia sẽ mật khẩu cho bất kì ai",
                                            from, passord).Wait();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var role = HttpContext.Session.GetString("role");
            var user1 = HttpContext.Session.GetString("user");
            if(id == Int32.Parse(user1))
            {
                TempData["checkuser"] = "true";
            }
          
            if (check.HasCredential(role, "EDIT_USERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
           if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,Fullname,Phone,Address,Status,RoleId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var role = HttpContext.Session.GetString("role");
            if (check.HasCredential(role, "DELETE_USERS", _context) == false)
            {
                return Redirect("/Home/Error");
            }
            else
           if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user.Status == 1)
            {
                user.Status = 0;
                _context.Users.Update(user);
              _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                user.Status = 1;
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            return View();


        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        public static string GeneratePassword(int passLength)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz@#$&ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, passLength)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
