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
        private object passTOMD5;
        private object strPro;

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
            if (checkSession() != 0)
            {
                return RedirectToAction(returnUrl);
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc,string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(acc.UserName) && !string.IsNullOrEmpty(acc.Password))
                {
                    using (var db = new LapTrinhQuanLyDBcontext())
                    {
                        var passToMD5 = strPro.GetMD5(acc.Password);
                        var account = db.Accounts.Where(m => m.UserName.Equals(acc.UserName) && m.Password.Equals(passTOMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UserName, false);
                            Session["idUser"] = acc.UserName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError("", "thông tin đăng nhập chưa chính xác ");
                    }
                }
                ModelState.AddModelError("", "UserName and password is required. ");
            }
            catch
            {
                ModelState.AddModelError("", "hệ thống đang được bảo chì vui lòng liên hệ với quản trị viên ");
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

