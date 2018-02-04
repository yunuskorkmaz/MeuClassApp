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
            return View();
        }
        public ActionResult ViewLesson(string number)
        {
            ViewBag.Number = number;
            return View();
        }
        public ActionResult AddLesson()
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.Title = "Ders Ekle | Admin Paneli";
                ClassAppContext context = new ClassAppContext();
                IEnumerable<User> users = new List<User>();
                users = context.User.Where(x => x.UserTypeID == 2);
                ViewBag.users = users;
                return View();
            }
        }
        public ActionResult AddLessonRegister(FormCollection form)
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
                return RedirectToAction("Index", "AdminLesson");

            }
            else
            {
                return RedirectToAction("AddLesson", "AdminLesson");
            }
        }
    }
}