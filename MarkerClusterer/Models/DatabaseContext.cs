using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MarkerClusterer.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
            //disable initializer
            Database.SetInitializer<DatabaseContext>(null);
        }

        public DbSet<Item> Items { get; set; }
    }
}