using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace edX.DataApp.Lab.CoreConsole
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductNumber { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }
    }
}
