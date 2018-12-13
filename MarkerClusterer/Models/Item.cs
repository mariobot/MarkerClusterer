using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkerClusterer.Models
{
    public class Item
    {
        public int id { get; set; }

        public string Name { get; set; }

        public type Nodo { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
        
    }

    public enum type { Compañia, Bloque, Campo, Cluster, Pozos }
    
}