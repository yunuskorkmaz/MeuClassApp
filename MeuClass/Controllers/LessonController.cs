using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(string number)
        {
            ViewBag.Number = number;
            return View();
        }

    }
}