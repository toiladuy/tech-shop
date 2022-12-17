﻿using Admin.Models;
using AdminWeb.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataFashionContext _context;
        CheckPermission check = new CheckPermission();
        public LoginController(DataFashionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [TempData]
        public string Message { get; set; }
        [HttpPost]
        public ActionResult LoginAdmin()
        {
            String email = HttpContext.Request.Form["Email"];
            String Pass = HttpContext.Request.Form["pass"];
            String btnLogin = HttpContext.Request.Form["login"];
            if(btnLogin != null)
            {
                var dataFashionContext = _context.Users.Include(u => u.Role);
                var data = dataFashionContext.Where(s => s.Email.Equals(email) && s.Password.Equals(Pass) && s.Status == 1 ).ToList();
                if(data.Count > 0)
                {
                    HttpContext.Session.SetString("user", data.FirstOrDefault().Id.ToString());
                    HttpContext.Session.SetString("role", data.FirstOrDefault().RoleId.ToString());
                    Message = data.FirstOrDefault().Fullname;
                    ViewBag.Message = "Success";
                    return Redirect("/Home");
                }
                

            }
            ViewBag.Message = "Fail";
            return Redirect("/Login");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
