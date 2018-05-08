using MeuClass.Business.Repository;
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
            var user = UserRepository.Instance.GetProfileInfo(id).Data;
            return PartialView(user);
        }
    }
}