using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarkerClusterer.Models
{
    public class Item
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Campo Requerido")]
        public string Name { get; set; }

        public type Nodo { get; set; }

        public int ParentId { get; set; }

        [RegularExpression(@"^-?[0-9]\d*(\.\d+)?$", ErrorMessage = "Error")]
        [Required(ErrorMessage = "Campo Requerido")]
        public double Latitude { get; set; }

        [RegularExpression(@"^-?[0-9]\d*(\.\d+)?$", ErrorMessage = "Error")]
        [Required(ErrorMessage = "Campo Requerido")]
        public double Longitude { get; set; } 
        
    }

    public enum type { Compañia, Bloque, Campo, Cluster, Pozos }
    
}