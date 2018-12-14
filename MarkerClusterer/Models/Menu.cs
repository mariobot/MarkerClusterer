using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkerClusterer.Models
{
    public class Menu
    {
        public Menu()
        {
            Childrens = new HashSet<Menu>();
        }

        public string url { get; set; }

        public int idItem { get; set; }

        public bool selected { get; set; }

        public ICollection<Menu> Childrens { get; set; }
    }
}