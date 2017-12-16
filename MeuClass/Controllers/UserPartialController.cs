using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Controllers
{
    public class UserPartialController : Controller
    {
        public ActionResult UserInfo(int id)
        {
            ViewBag.ID = id;
            return PartialView();
        }
    }
}