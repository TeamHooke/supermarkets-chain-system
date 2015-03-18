using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace XMLParser
{
    static class MySQLExport
    {
        private const string conString = "server=localhost;database=supermarketsmysql;uid=root;password=";
        private static MySqlConnection conn = new MySqlConnection(conString);

        public static void ConnectToMySQLDb()
        {
            conn.Open();
        }

        public static void FillDataIntoMySQLDb()
        {
            SupermarketsEntities db = new SupermarketsEntities();

            var vendors = db.Vendors;
            var products = db.Products;
            var expenses = db.Expenses;
            var incomes = from sale in db.Supermarket_Sales
                          join product in db.Products on sale.ProductId equals product.Id
                          group sale by new { VendorId = sale.SupermarketId, ProductId = sale.ProductId, Price = product.Price }
                              into g
                              select
                                  new
                                  {
                                      VendorId = g.Key.VendorId,
                                      ProductId = g.Key.ProductId,
                                      Income = db.Supermarket_Sales
                                          .Where(s => s.SupermarketId == g.Key.VendorId)
                                          .Where(p => p.ProductId == g.Key.ProductId)
                                          .Sum(count => count.CountOfSales) * g.Key.Price
                                  };

            MySqlCommand command = conn.CreateCommand();
            foreach (var vendor in vendors)
            {
                command.CommandText = "REPLACE INTO vendors (id ,vendor_name) " +
                                      "VALUES (" + vendor.Id + " ,'" + vendor.Name + "')";
                TryExecuteCommand(command, vendor.Name);
            }

            foreach (var product in products)
            {
                command.CommandText = "REPLACE INTO products (id, product_name, vendor_id) " +
                                      "VALUES (" + product.Id + ", '" + product.Name + "', " + product.VendorId + ")";
                TryExecuteCommand(command, product.Name);
            }

            foreach (var expense in expenses)
            {
                command.CommandText = "REPLACE INTO expenses (id, vendor_id, expense) " +
                                      "VALUES (" + expense.Id + ", " + expense.VendorId + ", '" + expense.Money + "')";
                TryExecuteCommand(command, expense.Money.ToString());
            }

            var IncomeId = 1;
            foreach (var income in incomes)
            {
                command.CommandText = "REPLACE INTO incomes (id, vendor_id, product_id, income) " +
                                      "VALUES (" + IncomeId++ + ", " + income.VendorId + ", " +
                                      income.ProductId + ", '" + income.Income + "')";
                TryExecuteCommand(command, income.ToString());
            }
        }

        private static void TryExecuteCommand(MySqlCommand command, string entryName)
        {
            try
            {
                command.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The entry '" + entryName + "' was added");
            }
            catch (MySqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The entry '" + entryName + "' already exists");
            }
        }

        public static void DisconnectFromMySQLDb()
        {
            conn.Close();
        }
    }
}
