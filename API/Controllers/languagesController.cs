﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class languagesController : Controller
    {
        // GET: languages
        public ActionResult Index()
        {
            return View();
        }
    }
}