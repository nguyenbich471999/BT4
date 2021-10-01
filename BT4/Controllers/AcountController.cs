using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BT4.Models;
using System.Web.Security;

namespace BT4.Controllers
{
    public class AcountController : Controller
    {
        Encrytion encry = new Encrytion();
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(AcountController acc)
        {
            if(ModelState.IsValid)
            {
                acc.Password = encry.PasswordEncrytion(acc.Password);
                db.Acounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
            [HttpGet]
            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            [AllowAnonymous]
            public ActionResult Login(Acount acc)
            {
                if (ModelState.IsValid)
                {
                    string encrytionpass = encry.PasswordEncrytion(acc.Password);
                    var model = db.Acounts.Where(m => m.Username == acc.Username && m.Password == encrytionpass).ToList().Count();
                    //thông tin đăng nhập chính xác
                    if (model == 1)
                    {
                        FormsAuthentication.SetAuthCookie(acc.Username, true);
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
        }
}