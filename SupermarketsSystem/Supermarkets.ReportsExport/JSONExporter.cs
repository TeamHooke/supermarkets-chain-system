using System;
using System.Linq;
using System.Data.Entity;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Xml;
using Supermarkets.Data;

namespace Supermarkets.ReportsExport
{
    public static class JSONExporter
    {
        public static void WriteToJSON(SupermarketsEntities db,
          DateTime startDate, DateTime endDate)
        {

             var sales =  from p in db.Products 
                          join v in db.Vendors on p.VendorId equals v.Id
                          orderby p.Id
                          group p by new { p.Id, p.Name, p.Price, VendorName = v.Name } into g
                          select new
                          {
                              ProductId = g.Key.Id,
                              ProductName = g.Key.Name,
                              VendorName = g.Key.VendorName,
                              TotalQuantitySold = db.Supermarket_Sales
                            .Where(pr => pr.ProductId == g.Key.Id &&
                                 pr.Date >= startDate && pr.Date <= endDate)
                            .Sum(b => b.CountOfSales),
                              TotalIncomes = db.Supermarket_Sales
                            .Where(pr => pr.ProductId == g.Key.Id &&
                                 pr.Date >= startDate && pr.Date <= endDate)
                            .Sum(b => b.CountOfSales) * g.Key.Price
                          };

           
            Directory.CreateDirectory("Json-Reports");

            foreach (var sale in sales)
            {
                using (StreamWriter file = File.CreateText("Json-Reports/" + sale.ProductId + ".json"))
                {
                    JObject JSONsale = new JObject();
                    JSONsale.Add("product-id", sale.ProductId);
                    JSONsale.Add("product-name", sale.ProductName);
                    JSONsale.Add("vendor-name", sale.VendorName);
                    JSONsale.Add("total-quantity-sold", sale.TotalQuantitySold);
                    JSONsale.Add("total-income", decimal.Round(sale.TotalIncomes,2));
                    string json = JsonConvert.SerializeObject(JSONsale, Newtonsoft.Json.Formatting.Indented);
                    file.WriteLine(json);
                }
            }

        }
    }
}
