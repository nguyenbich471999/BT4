using BT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT4.Controllers
{
    public class stdNewController : Controller
    {
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        StringProcess genkey = new StringProcess();
        // GET: stdnNew
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult Create()
        {

            var stdID = "";
            var countStudent = db.Students.Count();
            if (countStudent == 0)
            {
                stdID = "STD001";
            }
            else
            {
                var StudentID = db.Students.ToList().OrderByDescending(m => m.StudentID).FirstOrDefault().StudentID;
                stdID = genkey.Generatekey(StudentID);
            }
            ViewBag.studentID = stdID;
            return View();
           


        }
    }
}