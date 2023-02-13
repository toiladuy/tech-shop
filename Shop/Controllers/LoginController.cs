using Shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Shop.Utils;

namespace AdminWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataFashionContext _context;
        public LoginController(DataFashionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                return Redirect("/Home");
            }
            else
            {
                return View();
            }

        }
        public IActionResult IndexRes()
        {
            var user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                return Redirect("/Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult LoginAdmin()
        {
            string email = HttpContext.Request.Form["Email"];
            string password = HttpContext.Request.Form["pass"];
            string btnLogin = HttpContext.Request.Form["login"];
            if (btnLogin != null)
            {
                var dataFashionContext = _context.Users.Include(u => u.Role);
                var data = dataFashionContext.Where(s => s.Email.Equals(email) && PasswordUtils.VerifyHash(password, s.Password) && s.Status == 1).ToList();
                if (data.Count > 0)
                {
                    HttpContext.Session.SetString("user", data.FirstOrDefault().Id.ToString());

                    TempData["AlertType"] = "alert-success";
                    TempData["AlertMessage"] = "Login Success";
                    return Redirect("/Home");
                }


            }
            TempData["AlertType"] = "alert-warning";
            TempData["AlertMessage"] = "Wrong pass or Email";
            return Redirect("/Login");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            ViewBag.Message = "Success";
            return Redirect("/Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser([Bind("Email,Password,Fullname,Phone,Address")] User user)
        {
            if (ModelState.IsValid)
            {
                if (checkEmailExist(user.Email) == false)
                {
                    TempData["AlertType"] = "alert-warning";
                    TempData["AlertMessage"] = "Email is Exist";
                    return Redirect("/Login");
                }
                else
                {
                    user.Password = PasswordUtils.ComputeHash(user.Password, null);
                    user.Status = 1;
                    user.RoleId = "Customer";
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    TempData["AlertType"] = "alert-success";
                    TempData["AlertMessage"] = "Success";
                    return Redirect("/Login");
                }
            }
            TempData["AlertType"] = "alert-warning";
            TempData["AlertMessage"] = "Fail";
            return Redirect("/Login");
        }

        public ActionResult ChangeInfo()
        {
            String email = HttpContext.Request.Form["Email"];
            String Pass = HttpContext.Request.Form["Password"];
            String Fullname = HttpContext.Request.Form["Fullname"];
            String Address = HttpContext.Request.Form["Address"];
            String Phone = HttpContext.Request.Form["Phone"];
            String btnRes = HttpContext.Request.Form["res"];

            if (btnRes != null)
            {
                if (checkEmailExist(email) == false)
                {
                    ViewBag.Message = "Email is Exist";
                    return Redirect("/Login");
                }
                else
                {
                    User user = new User();
                    user.Email = email;
                    user.Password = Pass;
                    user.Address = Address;
                    user.Phone = Phone;
                    user.Fullname = Fullname;
                    user.Status = 1;
                    user.RoleId = "Customer";
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    ViewBag.Message = "Success";
                    return Redirect("/Login");
                }

            }
            return Redirect("");
        }
        public bool checkEmailExist(string Email)
        {
            var dataFashionContext = _context.Users.Include(u => u.Role);
            var data = dataFashionContext.Where(s => s.Email.Equals(Email)).ToList();
            if (data.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
