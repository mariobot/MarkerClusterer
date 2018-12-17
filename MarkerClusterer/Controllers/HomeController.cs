using MarkerClusterer.Models;
using MarkerClusterer.Services;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MarkerClusterer.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        PIWebAPIClient client = new PIWebAPIClient("mabotero", Encoding.UTF8.GetString(new byte[] { 76, 101, 110, 111, 118, 111, 50, 48, 49, 56 }));            

        public async Task<ActionResult> Navigation(int? id)
        {
            List<Item> LocationsAll = db.Items.ToList();
            List<Item> Locations = new List<Item>();
            type _type = new type();
            string url = string.Empty;
            Item _locationSelected = new Item();
            List<Indicators> _indicators = new List<Indicators>();

            if (id != null) {
                Locations = LocationsAll.Where(x => x.ParentId == id).ToList();
                _type = LocationsAll.Where(x => x.id == id).Select(x => x.Nodo).FirstOrDefault();
                url = PIWebAPIClient.RequestDirectory(_type.ToString());
                JObject data = await client.GetAsync(url);
                _indicators = CastData(data);
                _locationSelected = LocationsAll.Where(x => x.id == id).FirstOrDefault();
            }

            VMNavigation _vm = new VMNavigation() {
                Locations = Locations,
                MyMenu = BuildMenu(id),
                IndicatorsValues = _indicators,
                LocationSelected = _locationSelected
            };

            return View(_vm);
        }

        public static List<Indicators> CastData(JObject _data)
        {
            List<Indicators> _indicators = new List<Indicators>(); 
            foreach (var item in _data["Items"])
            {
                Indicators i = new Indicators() {
                    NameIndicator = item["Name"].ToString(),
                    Value = item["Value"]["Value"].ToString()
                };
                _indicators.Add(i);
            }
            return _indicators;
        }

        public ActionResult Menu(int? id)
        {
            List<Menu> MenuItems = BuildMenu(id);
            return View(MenuItems);
        }

        public List<Menu> BuildMenu(int? id)
        {
            List<Item> Locations = db.Items.ToList();
            List<Menu> MenuItems = new List<Menu>();
            Menu m = new Menu();

            foreach (var root in Locations)
            {
                if (root.ParentId == 0)
                {
                    m = AddMenuItem(root, id);

                    foreach (var bloque in Locations.Where(x => x.ParentId == root.id))
                    {
                        Models.Menu menuBloque = AddMenuItem(bloque, id);

                        foreach (var campo in Locations.Where(x => x.ParentId == bloque.id))
                        {
                            Models.Menu menuCampo = AddMenuItem(campo, id);

                            foreach (var cluster in Locations.Where(x => x.ParentId == campo.id))
                            {
                                Models.Menu menuCluster = AddMenuItem(cluster, id);

                                foreach (var pozos in Locations.Where(x => x.ParentId == cluster.id))
                                {
                                    Models.Menu menuPozos = AddMenuItem(pozos, id);
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
            return MenuItems;
        }

        private static Menu AddMenuItem(Item root, int? id)
        {
            bool _selected = false;
            if (id == root.id)
                _selected = true;

            return new Menu()
            {
                idItem = root.id,
                selected = _selected,
                url = "Route/" + root.id,
                Nodo = root.Nodo.ToString(),
                Text = root.Name,
            };
        }

        public ActionResult GoogleMaps(int? id)
        {

            List<Item> Locations = db.Items.ToList();

            if (id != null)
                Locations = Locations.Where(x => x.ParentId == id).ToList();

            return View(Locations);
        }
    }
}