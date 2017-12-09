
using MeuClass.Business.Repository;
using MeuClass.Controllers.Messages.Controller;
using MeuClass.Entity.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MeuClass.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Session["user_id"] == null)
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
            if(TempData["error"] != null)
            {
                ViewBag.Error = TempData["error"].ToString();

            }
            return View();
        }

        public ActionResult DoLogin(FormCollection form)
        {
            


            var check = UserRepository.Instance.CheckAuth(form.Get("SchoolNumber"),form.Get("Password"));

            if(check == null)
            {
                TempData["error"] = "Giriş Yapılamadı";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                Session["user_id"] = check.UserID;
                Session["name"] = check.Name;
                Session["surname"] = check.Surname;
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
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now

            };


            try
            {
                UserRepository.Instance.Add(user);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.ToString() + "hata";
            }

            return RedirectToAction("Index", "Home");            
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

       
    }
}