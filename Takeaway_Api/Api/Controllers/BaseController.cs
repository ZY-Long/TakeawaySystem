﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class BaseController : Controller
    {
        
        public ActionResult Index()
        {
            //噶王你会吃屎吗
            return View();
        }
      
    }
}