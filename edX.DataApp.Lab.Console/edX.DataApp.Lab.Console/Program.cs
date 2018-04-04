using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace edX.DataApp.Lab.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();
        }

        static async Task RunAsync()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                System.Console.WriteLine("Connection has opened successfully");
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT COUNT(CustomerId) AS CustomerCount, SalesPerson AS Contributor, MAX(CustomerID) AS LastContribution 
                                        FROM Customers GROUP BY SalesPerson ORDER BY CustomerCount DESC";
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    System.Console.WriteLine($"{await reader.GetFieldValueAsync<string>(1),25}\t{await reader.GetFieldValueAsync<int>(0):000} Customers\tLast Change: ({(await reader.GetFieldValueAsync<int>(2)):000})");
                }
            }
        }
    }
}
