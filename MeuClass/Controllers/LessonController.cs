
using MeuClass.Business.Repository;
using MeuClass.Data;
using System;
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

        public ActionResult AddLesson()
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.Title = "Ders Ekle";
                return View();
            }
        }
        public ActionResult DoRegister (FormCollection form)
        {
            var lesson = new Lesson()
            {
                LessonCode = form.Get("lessonCode"),
                LessonName = form.Get("lessonName"),
                RecordDate = DateTime.Now
            };

            var insert = LessonRepository.Instance.Add(lesson);

            if (insert.Success == false)
            { 
                TempData["error"] = insert.Message;
                return RedirectToAction("detail", "Lesson");

            }
            else
            {
                return RedirectToAction("AddLesson", "Lesson");
            }
        }

    }
}