using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: Admin/AdminUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUser(string number)
        {
            ViewBag.Number = number;
            return View();
        }
        public ActionResult ViewUser(string number)
        {
            ViewBag.Number = number;
            return View();
        }
    }
}