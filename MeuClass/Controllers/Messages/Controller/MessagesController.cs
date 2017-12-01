using MeuClass.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Controllers.Messages.Controller
{
    public class MessagesController : BaseController
    {
        // GET: Messages

       

        public ActionResult Index()
        {
            
            return View();

        }
    }
}