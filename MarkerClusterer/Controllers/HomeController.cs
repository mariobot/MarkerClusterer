using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
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

        public ActionResult Menu()
        {
            List<Item> Locations = db.Items.ToList();
            List<Menu> MenuItems = new List<Menu>();
            Menu m = new Menu();

            foreach (var root in Locations)
            {
                if (root.ParentId == 0)
                {
                    m = AddMenuItem(root);

                    foreach (var bloque in Locations.Where(x => x.ParentId == root.id)){
                        Models.Menu menuBloque = AddMenuItem(bloque);

                        foreach (var campo in Locations.Where(x => x.ParentId == bloque.id)){
                            Models.Menu menuCampo = AddMenuItem(campo);

                            foreach (var cluster in Locations.Where(x => x.ParentId == campo.id)){
                                Models.Menu menuCluster = AddMenuItem(cluster);

                                foreach (var pozos in Locations.Where(x => x.ParentId == cluster.id)){
                                    Models.Menu menuPozos = AddMenuItem(pozos);
                                    menuCluster.Childrens.Add(menuPozos);
                                }
                                menuCampo.Childrens.Add(menuCluster);
                            }
                            menuBloque.Childrens.Add(menuCampo);
                        }
                        m.Childrens.Add(menuBloque);
                    }
                    MenuItems.Add(m);
                }
            }
            return View(MenuItems);
        }

        private static Menu AddMenuItem(Item root)
        {
            return new Menu()
            {
                idItem = root.id,
                selected = false,
                url = "Route/" + root.id,
                Nodo = root.Nodo.ToString(),
                Text = root.Name,
            };
        }
    }
}