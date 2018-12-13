using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkerClusterer.Models;

namespace MarkerClusterer.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GoogleMaps() {

            List<Item> Locations =  db.Items.ToList();

            ViewBag.Locations = @"{'name': 'Mario','p' : '' }";

            return View(Locations);
        }
    }
}