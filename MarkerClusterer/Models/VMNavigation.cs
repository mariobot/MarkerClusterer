using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkerClusterer.Models
{
    public class VMNavigation
    {
        public List<Item> Locations { get; set; }
        public List<Menu> MyMenu { get; set; }
        public Item LocationSelected { get; set; }
        public List<Indicators> IndicatorsValues { get; set; }
    }
}