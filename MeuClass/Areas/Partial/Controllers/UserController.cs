using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuClass.Business.Repository;

namespace MeuClass.Areas.Partial.Controllers
{
    public class UserController : Controller
    {
        // GET: Partial/User
        public ActionResult MainPageInfo()
        {
            var result = UserRepository.Instance._getByID((int)Session["user_id"]);
            if (result.Data != null)
            {
                return View(result.Data);
            }
            else
            {
                return null;
            }
        }
        public ActionResult Detail(int userid)
        {
            var user = UserRepository.Instance.GetProfileInfo(userid).Data;
            return View(user);
        }

        public ActionResult About(int userid)
        {
            var user = UserRepository.Instance.GetProfileInfo(userid).Data;
            return View(user);
        }


        public ActionResult Lesson(int userid)
        {
            var user_id = Convert.ToInt32(userid);
            var data = UserRepository.Instance._getByID(user_id).Data.LessonAccesses.Select(a => a.Lesson).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult EditProfile(int userid)
        {
            var user = UserRepository.Instance.GetProfileInfo(userid).Data;
            return View(user);
        }


        public ActionResult Info()
        {
            return View();
        }
    }
}