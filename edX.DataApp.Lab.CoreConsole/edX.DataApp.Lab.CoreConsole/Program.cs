using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace edX.DataApp.Lab.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ContosoContext context = new ContosoContext())
            {
                Console.WriteLine("Connection Successful");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("------------------------------------------------------------");
                // question 1 answer
                string q1 = "SH-W890-M";
                var q1a = context.Products.FirstOrDefault(p => String.Equals(p.ProductNumber, q1));
                Console.WriteLine($"Question 1 Answer: {(q1a.ListPrice - q1a.StandardCost),0:C2}\n");
                // question 2 answer
                string[] q2 = new string[]
                {
                    "FR-R92R-44",
                    "BK-R93R-48",
                    "BK-R89B-52",
                    "BK-M68B-46",
                    "BK-T44U-46"
                };
                var q2as = context.Products
                    .Where(p => q2.Contains(p.ProductNumber) && (p.ListPrice - p.StandardCost) > 1000)
                    .ToArray();
                Console.Write("Question 2 Answer: ");
                foreach (var q2a in q2as)
                    Console.Write($"{q2a.ProductNumber}  ");
                Console.WriteLine(Environment.NewLine);
                // question 3 answer
                string q3 = "FR-M21B-40";
                var q3a = context.Products.FirstOrDefault(p => String.Equals(p.ProductNumber, q3));
                Console.WriteLine($"Question 3 Answer: {q3a.StandardCost,0:C2}");
                Console.WriteLine("------------------------------------------------------------");
            }
            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
