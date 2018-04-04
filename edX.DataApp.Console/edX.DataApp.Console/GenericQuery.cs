using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace edX.DataApp.Console
{
    public class GenericQuery
    {
        public async Task<IEnumerable<Customer>> RunLogic(SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT TOP(25) CustomerID, CompanyName, EmailAddress, Phone FROM Customers";
            List<Customer> customerList = new List<Customer>();
            SqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                Customer item = new Customer()
                {
                    Id = reader.GetInt32(0),
                    Company = reader.GetString(1),
                    Email = reader.GetString(2),
                    Phone = reader.GetString(3)
                };
                customerList.Add(item);
            }
            return customerList;
        }
    }
}
