using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarkerClusterer.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DefaultConnection") { }

        public DbSet<Item> Items { get; set; }

    }
}