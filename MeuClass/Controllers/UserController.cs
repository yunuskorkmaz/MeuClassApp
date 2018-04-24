
using MeuClass.Business.Repository;
using MeuClass.Data;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MeuClass.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Profile(int number)
        {
            var user = UserRepository.Instance.GetProfileInfo(number).Data;
           
            return View(user);
        }
        

        public ActionResult About(string number)
        {
            ViewBag.Number = number;
            return View();
        }

        public ActionResult Friends(string number)
        {
            ViewBag.Number = number;
            return View();
        }

        public ActionResult Lesson(string number)
        {
            ViewBag.Number = number;
            return View();
        }

        public ActionResult Search(FormCollection form)
        {

            var name = form.Get("NameSurname");
           

                return View();
           
        }
    }
}