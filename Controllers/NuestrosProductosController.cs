﻿using Hubbell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hubbell.Controllers
{
    public class NuestrosProductosController : Controller
    {
        [HttpGet]
        public ActionResult AboveGround()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BoxPad()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pedestales()
        {
            return View();
        }

        [HttpGet]
        public ActionResult HotBoxMetal()
        {
            return View();
        }

        [HttpGet]
        public ActionResult HotBoxFibra()
        {

            return View();
        }

        [HttpGet]
        public ActionResult NuestrosClientes()
        {

            return View();
        }
    }
}
