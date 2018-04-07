using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edX.DataApp.CoreConsole
{
    public class ProductQuery
    {
        public void RunLogic(ContosoContext context)
        {
            IEnumerable<Product> products =
                        from product in context.Products
                        where product.SafetyReviewResult ?? false
                        select product;
            foreach (var product in products)
            {
                Console.WriteLine($@"[{product.ProductNumber}]\t{product.Name,35}\tPassed Review: {product.SafetyReviewResult}");
            }
        }
    }
}
