
using MeuClass.Business.Repository;
using MeuClass.Data;
using System;
using System.Web.Mvc;

namespace MeuClass.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.Title = "Anasayfa";
                return View();
            }
        }



        public ActionResult Login()
        {
            if (TempData["error"] != null)
            {
                ViewBag.Error = TempData["error"].ToString();

            }
            return View();
        }

        public ActionResult DoLogin(FormCollection form)
        {

            var result = UserRepository.Instance.CheckAuth(form.Get("SchoolNumber"), form.Get("Password"));

            if (result.Success == false)
            {
                TempData["error"] = result.Message;
                return RedirectToAction("Login", "Home");
            }
            else
            {
                Session["user_id"] = result.Data.UserID;
                Session["name"] = result.Data.Name;
                Session["surname"] = result.Data.Surname;
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult DoRegister(FormCollection form)
        {


            var user = new User()
            {
                Name = form.Get("Name"),
                Surname = form.Get("Surname"),
                SchoolNumber = form.Get("SchoolNumber"),
                Password = form.Get("Password"),
                Birthday = DateTime.Now,
                RecordDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UserTypeID = 1
            };

            var insert = UserRepository.Instance.Add(user);

            if (insert.Success == false)
                TempData["error"] = insert.Message;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}