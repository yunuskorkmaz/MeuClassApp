using MeuClass.Business.Repository;
using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Areas.Admin.Controllers
{
    public class AdminLessonController : Controller
    {
        // GET: Admin/AdminLesson
        public ActionResult Index()
        {
            return Json(new { test = "test"});
        }
        public ActionResult ViewLesson(string number)
        {
            ViewBag.Number = number;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            
                ViewBag.Title = "Ders Ekle | Admin Paneli";
                var users = UserRepository.Instance.Search(x => x.UserTypeID == 2);
                return View(users.Data);
            
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var lesson = new Lesson()
            {
                LessonName = form.Get("lessonName"),
                LessonCode = form.Get("lessonCode"),
                RecordDate = DateTime.Now
            };

            var insert = LessonRepository.Instance.Add(lesson);

            if (insert.Success == false)
            {
                TempData["error"] = insert.Message;
                return RedirectToAction("Index", "AdminLesson",new {Area= "Admin"});

            }
            else
            {
                return RedirectToAction("Add", "AdminLesson", new { Area = "Admin" });
            }
        }
    }
}