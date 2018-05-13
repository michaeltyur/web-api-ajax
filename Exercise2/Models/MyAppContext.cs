using Exercise2.DbInitializer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exercise2.Models
{
    public class MyAppContext:DbContext
    {
        public MyAppContext() : base("AppAjaxContext")
        {
            Database.SetInitializer(new AppDbInitializer());
        }
        public DbSet<ShopItem> ShopItems { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}