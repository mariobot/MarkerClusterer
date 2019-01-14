using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkerClusterer.Controllers
{
    public class ConfigurationController : Controller
    {
        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult ParamsReports()
        {
            return View();
        }

        public ActionResult Alarms()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Documents()
        {
            return View();
        }
    }
}