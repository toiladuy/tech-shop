using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.SendMail;
using Shop.Utils;
using System;
using System.Data.Entity;
using System.Linq;

namespace AdminWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly PhTechContext _context;

        public LoginController(PhTechContext context)
        {
            _context = context;
        }

        [HttpGet]
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

        [HttpPost]
        public ActionResult Login()
        {
            string email = HttpContext.Request.Form["Email"];
            string password = HttpContext.Request.Form["pass"];
            User user = _context.Users.FirstOrDefault(s => s.Email.Equals(email));
            if (user != null)
            {
                if (PasswordUtils.VerifyHash(password, user.Password))
                {
                    HttpContext.Session.SetString("user", user.Id.ToString());
                    if (user.Status == 1)
                    {
                        TempData["AlertType"] = "alert-success";
                        TempData["AlertMessage"] = "Login Success";
                        return Redirect("/Home");
                    }
                    else
                    {
                        return Redirect("CheckActivation");
                    }
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

        [HttpGet]
        public IActionResult Register()
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
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser([Bind("Email,Password,Fullname,Phone,Address")] User user)
        {
            if (ModelState.IsValid)
            {
                if (checkEmailExist(user.Email) == false)
                {
                    TempData["AlertType"] = "alert-warning";
                    TempData["AlertMessage"] = "Email was existed.";
                    return Redirect("/Login");
                }
                else
                {
                    user.Password = PasswordUtils.ComputeHash(user.Password, null);
                    user.Status = 0;
                    user.RoleId = "Customer";
                    _context.Users.Add(user);
                    _context.SaveChanges();

                    HttpContext.Session.SetString("user", user.Id.ToString());

                    UserActivation userActivation = new UserActivation() { UserId = user.Id };
                    _context.UserActivations.Add(userActivation);
                    _context.SaveChanges();

                    ResendActivationEmail(user, userActivation);

                    TempData["AlertType"] = "alert-success";
                    TempData["AlertMessage"] = "Success";
                    return Redirect("CheckActivation?action=register");
                }
            }
            TempData["AlertType"] = "alert-warning";
            TempData["AlertMessage"] = "Fail";
            return Redirect("/Login");
        }

        private void ResendActivationEmail(User user, UserActivation userActivation)
        {
            string email = "<p>Hi " + user.Fullname + ",</p>" +
                "<p>Thank you for registering new account on PH-Tech.</p>" +
                "<p>To activate your account, please click the following link:</p><br/><br/>" +
                "<a href='https://localhost:44398/Login/Activate?code=" + userActivation.Code + "' target='_blank' " +
                "style='padding:1rem 1.5rem;background-color:#7267e9;color:#fff;text-transform:uppercase;text-decoration:none;'>Activate account</a><br/><br/>";
            MailUtils.SendMailGoogleSmtp(user.Email, "Please activate your account", email).Wait();
        }

        [HttpGet]
        public IActionResult Activate([FromQuery(Name = "code")] string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Redirect("/Home");
            }

            var userActivation = _context.UserActivations.FirstOrDefault(a => a.Code.Equals(code) && a.Status == 0);
            if (userActivation == null)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "Activation code is no longer valid.";
                return Redirect("/Login/CheckActivation");
            }
            if (userActivation.ExpiredAt <= DateTime.Now)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "Activation code is no longer valid.";
                return Redirect("/Login/CheckActivation");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userActivation.UserId);
            if (user == null)
            {
                return Redirect("/Login");
            }

            user.Status = 1;
            _context.Users.Update(user);
            _context.SaveChanges();

            userActivation.Status = 1;
            _context.UserActivations.Update(userActivation);
            _context.SaveChanges();

            TempData["AlertType"] = "alert-info";
            TempData["AlertMessage"] = "Activating your account successfully.";
            return Redirect("/Login/CheckActivation");
        }

        [HttpGet]
        public IActionResult CheckActivation([FromQuery(Name = "action")] string action)
        {
            var userId = HttpContext.Session.GetString("user");
            if (userId == null)
            {
                return Redirect("/Login");
            }
            int uid = int.Parse(userId);
            User user = _context.Users.FirstOrDefault(s => s.Id == uid);
            if (user == null)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "User not found.";
                return Redirect("/Login");
            }
            ViewData["JustRegistered"] = !string.IsNullOrEmpty(action);
            ViewData["Activated"] = user.Status == 1;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResendActivation()
        {
            var userId = HttpContext.Session.GetString("user");
            if (userId == null)
            {
                return Redirect("/Login");
            }
            int uid = int.Parse(userId);
            User user = _context.Users.FirstOrDefault(s => s.Id == uid);
            if (user == null)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "User not found.";
                return Redirect("/Login");
            }
            UserActivation userActivation = _context.UserActivations.FirstOrDefault(a => a.UserId == uid && a.Status == 0);
            if (userActivation == null)
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = "Activation is no longer valid.";
                return Redirect("/Login");
            }
            ResendActivationEmail(user, userActivation);
            TempData["AlertType"] = "alert-info";
            TempData["AlertMessage"] = "Activation email has been resent.";
            return Redirect("CheckActivation");
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
            var phContext = _context.Users.Include(u => u.Role);
            var data = phContext.Where(s => s.Email.Equals(Email)).ToList();
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
