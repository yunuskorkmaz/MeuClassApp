using MeuClass.Business.Repository;
using MeuClass.Data;
using System;
using System.Web.Mvc;

namespace MeuClass.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: Admin/AdminUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {

            ViewBag.Title = "Üye Ekle | Admin Paneli";
            var usertypes = UserTypeRepository.Instance.GetAll();
            return View(usertypes.Data);

        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            var user = new User()
            {
                Name = form.Get("userName"),
                Surname = form.Get("userSurname"),
                Password=form.Get("userPassword"),
                SchoolNumber=form.Get("userNumber"),
                UserTypeID =Convert.ToInt32(form.Get("userType")),
                RecordDate = DateTime.Now,
            };
            var insert = UserRepository.Instance.Add(user);

            if (insert.Success == false)
            {
                TempData["error"] = insert.Message;
                return RedirectToAction("Index", "AdminUser", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("Add", "AdminUser", new { Area = "Admin" });
            }
        }
        public ActionResult ViewUser(string number)
        {
            ViewBag.Number = number;
            return View();
        }

        public ActionResult Edit(string number)
        {
            ViewBag.Number = number;
            return View();
        }
    }
}