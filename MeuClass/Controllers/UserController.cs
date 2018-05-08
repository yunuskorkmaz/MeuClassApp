
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
        public ActionResult Profile(int number,string subview="")
        {
            var user = UserRepository.Instance.GetProfileInfo(number).Data;
            ViewBag.SubView = subview;
            return View(user);
        }
        

        public ActionResult Search(FormCollection form)
        {

            var name = form.Get("NameSurname");
           

                return View();
           
        }
    }
}