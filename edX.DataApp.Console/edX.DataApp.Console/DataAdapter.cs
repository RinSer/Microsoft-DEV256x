using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace edX.DataApp.Console
{
    public class DataAdapter
    {
        public async Task RunLogic(SqlConnection connection)
        {
            string query = @"SELECT TOP(20) CustomerID AS Id, FirstName AS First, LastName AS Last 
                             FROM Customers WHERE LEN(FirstName) < 7";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach(DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        System.Console.Write("{0}\t", row[column]);
                    }
                    System.Console.WriteLine();
                }
            }
        }
    }
}
