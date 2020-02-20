﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DownloadTerms()
        {
            return File("~/Content/BusinessTerms.pdf",
                "application/pdf", "BusinessTerms.pdf");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}