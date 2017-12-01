using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Admin
{
    public class BaseController : Controller
    {
        // GET: Base
       
        public BaseController()
        {
            
            
        }

        public ActionResult ChanceAction()
        {

            if (Session["user_id"].ToString() == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return null;
           
        }
    }
}