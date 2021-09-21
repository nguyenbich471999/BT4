using BT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT4.Controllers
{
    public class stdnNewController : Controller
    { 
        LapTrinhQuanLyDBcontext db=new LapTrinhQuanLyDBcontext()
        // GET: stdnNew
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
    }
}