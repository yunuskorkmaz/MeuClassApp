using MeuClass.Areas.Admin.Models;
using MeuClass.Business.Repository;
using MeuClass.Data;
using System;
using System.Threading.Tasks;
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
            var usertypes = UserTypeRepository.Instance._getAll();
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
        public ActionResult ViewUser()
        {

            var repo = UserRepository.Instance;
            
                ViewBag.Title = "Ders Ekle | Admin Paneli";

                var users =  repo.GetList();
                return  View(users.Data);
            
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = UserRepository.Instance._getByID(id);
            var usertypes = UserTypeRepository.Instance._getAll();

            var result = new UserViewModel()
            {
                User = user.Data,
                UserTypes = usertypes.Data
            };

            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            var user = new User()
            {
                UserID = Convert.ToInt32(form.Get("userid")),
                Name = form.Get("usereditName"),
                Surname = form.Get("usereditSurname"),
                SchoolNumber = form.Get("usereditNumber"),
                UserTypeID =  Convert.ToInt32(form.Get("usereditType")) ,
                UpdateDate = DateTime.Now

            };
            var UpdateUser = UserRepository.Instance.Update_User(user);

            if (UpdateUser.Success == false)
            {
                TempData["error"] = UpdateUser.Message;
               
            }
            return RedirectToAction("Edit", "AdminUser", new { Area = "Admin" ,@id= Convert.ToInt32(form.Get("userid"))});

        }
    }
}