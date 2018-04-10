using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace edX.DataApp.Lab.MVC.Models
{
    public class ContosoContext : DbContext
    {
        public ContosoContext() : base(@"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;")
        { }

        public DbSet<Partner> Partners { get; set; }
    }
}