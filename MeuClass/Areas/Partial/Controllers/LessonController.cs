using MeuClass.Business.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MeuClass.Areas.Partial.Controllers
{
    public class LessonController : Controller
    {
       
        public ActionResult MainPageSide()
        {
            var userid = Convert.ToInt32(Session["user_id"]);
            var data = UserRepository.Instance._getByID(userid).Data.LessonAccesses.Select(a=>a.Lesson).ToList();
            return View(data);
        }

        public ActionResult DetailContents(int lessonid)
        {
            return View();
        }

        public ActionResult DetailFiles(int lessonid)
        {
            return View();
        }

        public ActionResult DetailMembers(int lessonid)
        {
            return View();
        }
    }
}