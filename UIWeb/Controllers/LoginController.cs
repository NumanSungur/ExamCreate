using Business.Manager;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using Microsoft.AspNetCore.Http;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager userBll;
        public LoginController(UserManager _userBll)
        {
            userBll = _userBll;
        }
        public IActionResult Index()
        {
            ViewBag.Error = "";
            return View(new LoginModel());

        }
        [HttpPost]
        public IActionResult Index(LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                User userresult = userBll.Login(new User() { UserName = user.UserName, Password = user.Password });
                if (userresult != null)
                {
                    HttpContext.Session.SetInt32("UserID",userresult.ID);
                    return RedirectToAction("Index", "Exam");
                }
                else
                {
                    ViewBag.Error = "Lütfen Kullanıcı Adı veya Şifrenizi doğru olduğuna emin olunuz";
                    return View("Index");

                }
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RegisterModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            else
            {
                bool userresult = userBll.Create(new User() { FullName = user.FullName, UserName = user.UserName, Password = user.Password });
                if (userresult == true)
                {
                    ViewBag.Success = true;
                    ViewBag.Error = "Üye Kaydınız Yapıldı Lütfen Giriş Yapınız";
                    return View("Index");
                }
                else
                {
                    ViewBag.Error = "Kulllanıcı Kaydı Yapılamadı .Lütfen bilgileri doğru olduğuna emin olunuz";
                    return View("Create");

                }
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}
