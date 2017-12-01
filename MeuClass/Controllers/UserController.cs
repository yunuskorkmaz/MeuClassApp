using DataAccess;
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

        public ActionResult Search(FormCollection form)
        {

            var name = form.Get("NameSurname");
            using (var db = new ClassAppEntities())
            {
                var result = db.DBUsers.Where(a => a.Name.Contains(name) || a.Surname.Contains(name)).ToList();

                return View(result);
            }
        }
    }
}