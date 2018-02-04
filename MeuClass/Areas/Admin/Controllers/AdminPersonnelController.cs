using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Areas.Admin.Controllers
{
    public class AdminPersonnelController : Controller
    {
        // GET: Admin/AdminPersonnel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPersonnel(string number)
        {
            ViewBag.Number = number;
            return View();
        }
        public ActionResult ViewPersonnel(string number)
        {
            ViewBag.Number = number;
            return View();
        }
    }
}