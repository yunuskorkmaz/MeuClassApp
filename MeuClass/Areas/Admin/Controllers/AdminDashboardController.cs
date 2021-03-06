﻿using MeuClass.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuClass.Areas.Admin.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: Admin/AdminDashboard
        [CheckAuth(UserRole.OnlyAdmin)]
        public ActionResult Index()
        {
            return View();
        }
    }
}