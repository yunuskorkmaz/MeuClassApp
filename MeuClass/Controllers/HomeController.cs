using DataAccess;
using MeuClass.Controllers.Messages.Controller;
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
            using (var context = new ClassAppEntities())
            {
                var number = form.Get("SchoolNumber");
                var pass = form.Get("Password");
                var query = context.DBUsers.Where(a => a.SchoolNumber == number && a.Password == pass).FirstOrDefault();
                if(query != null)
                {
                    Session["user_id"] = query.ID;
                    Session["name"] = query.Name;
                    Session["surname"] = query.Surname;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Giriş Yapılamadı";
                    return RedirectToAction("Login", "Home");
                }
            }
        }

        public ActionResult DoRegister(FormCollection form)
        {
            using (var context = new ClassAppEntities())
            {
                try
                {

                    var user = new DBUsers()
                    {
                        Name = form.Get("Name"),
                        Surname = form.Get("Surname"),
                        SchoolNumber = form.Get("SchoolNumber"),
                        Password = form.Get("Password")
                    };
                    var id = context.DBUsers.Add(user);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    TempData["error"] = ex.ToString() +" hata";

                }
                
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