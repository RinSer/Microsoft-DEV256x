using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace edX.DataApp.Lab.WebAPI.Models
{
    public class ContosoContext : DbContext
    {
        public ContosoContext()
        : base(@"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;")
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}