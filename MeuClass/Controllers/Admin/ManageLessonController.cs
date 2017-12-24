using MeuClass.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Controllers.Admin
{
    public class ManageLessonController : Controller
    {
        public ManageLessonController()
        {
           var type =  UserRepository.Instance.GetUserTypeById(Convert.ToInt32(Session["user_id"]));
           if(type.UserTypeID != 1) { RedirectToAction("Index", "Home"); }
        }
        // GET: ManageLesson
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateLesson()
        {
            ViewBag.Title = "Ders Ekle";
            return View();
        }
    }
}