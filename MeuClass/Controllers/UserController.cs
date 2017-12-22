
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

        public ActionResult Profile(string number)
        {
            ViewBag.Number = number;
            return View();
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