using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BT4.Models;

namespace LapTrinhQuanLyDb.Controllers
{
    public class AccontController : Controller
    {
        Encrytion encry = new Encrytion();
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        // GET: Accont
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                //mã hóa mật khẩu trước khi lưu vào database
                acc.Password = encry.passwordEncrytion(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", " Account");
            }
            return View(acc);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (checkSession() == 1)
            {
                return RedirectToAction("Index", "Home_Ad", new { Area = "Admins" });
            }
            else if (checkSession() == 2)
            {
                return RedirectToAction("Index", "Home_Le", new { Area = "Lectures" });
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = encry.passwordEncrytion(acc.Password);
                var model = db.Accounts.Where(m => m.UserName == acc.UserName && m.Password == encrytionpass).ToList().Count();
                //thông tin đăng nhập chính xác
                if (model == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    return RedirectToAction("Index", " Home");
                }
                else
                {
                    ModelState.AddModelError("", "THông tin đăng nhập không chính xác ");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
        private int checkSession()
        {
            using (var db = new LapTrinhQuanLyDBcontext())
            {
                var user = HttpContext.Session["iduser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "NV")
                        {
                            return 2;
                        }
                    }
                }
            }

            return 0;
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (String.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (checkSession() == 1)
                {
                    return RedirectToAction("Index", "Home_Ad", new { Area = "Admins" });
                }
                else if (checkSession() == 2)
                {
                    return RedirectToAction("Index", "Home_Le", new { Area = "Lectures" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home_Ad");
            }
        }
    }
}

