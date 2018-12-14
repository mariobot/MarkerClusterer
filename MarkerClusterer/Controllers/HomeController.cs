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

        public ActionResult GoogleMaps(int? id) {

            List<Item> Locations =  db.Items.ToList();

            if (id != null)            
                Locations = Locations.Where(x => x.ParentId == id).ToList();            

            return View(Locations);
        }

        public ActionResult Menu() {

            List<Item> Locations = db.Items.ToList();

            return View(Locations);
        }
    }
}