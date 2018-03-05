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

        public ActionResult Info()
        {
            return View();
        }
    }
}