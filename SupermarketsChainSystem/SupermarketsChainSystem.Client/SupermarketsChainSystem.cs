using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketChainSystem.Model;
namespace SupermarketsChainSystem.Client
{
    public class SupermarketsChainSystem
    {
        public static ExcelManager ExcelManager = new ExcelManager();
        public static ZipManager zm = new ZipManager();
        public static List<StoreReport> SupermarketsReports = new List<StoreReport>();

        public static void Main()
        {
            SystemManager.DropFolder(SystemManager.tempDir);
            foreach (string file in Directory.EnumerateFiles(SystemManager.reportsDir, "*.*", SearchOption.AllDirectories))
            {
                zm.UnZipFile(file, SystemManager.tempDir);
                foreach (string excelFile in Directory.EnumerateFiles(SystemManager.tempDir, "*.*", SearchOption.AllDirectories))
                {
                    StoreReport storeReport = ExcelManager.GetData(excelFile);
                    SupermarketsReports.Add(storeReport);
                }
                SystemManager.DropFolder(SystemManager.tempDir);
            }

            SupermarketsEntities db = new SupermarketsEntities();

            foreach (var report in SupermarketsReports)
            {
                //   Console.WriteLine("Store name: " + report.StoreName);
                if (!db.Supermarkets.Any(x => x.Location == report.StoreName))
                {
                    var supermarket = new Supermarket();
                    supermarket.Location = report.StoreName;
                    db.Supermarkets.Add(supermarket);
                    db.SaveChanges();

                }

                var getSupermarket = db.Supermarkets.Where(x => x.Location == report.StoreName).First();
                var supermarketId = getSupermarket.Id;


                foreach (var product in report.productReports)
                {
                    //   Console.WriteLine(string.Format("Product name: {0}, Quantity: {1}, Unit price: {2}, Sum: {3} ", product.ProductName, product.Quantity, product.UnitPrice, product.Sum));
                    if (!db.Products.Any(x => x.Name == product.ProductName))
                    {
                        var newProduct = new Product();
                        newProduct.MeasureId = 1;
                        newProduct.VendorId = 1;
                        newProduct.Name = product.ProductName;
                        newProduct.Price = 12;
                        db.Products.Add(newProduct);
                        db.SaveChanges();
                    }
                    var productId = (db.Products.Where(x => x.Name == product.ProductName).First()).Id;

                    var productReport = new Supermarket_Sales();
                    productReport.ProductId = productId;
                    productReport.SupermarketId = supermarketId;
                    productReport.CountOfSales = product.Quantity;
                    productReport.Date = DateTime.Now;
                    db.Supermarket_Sales.Add(productReport);
                    db.SaveChanges();
                }

                // Console.WriteLine("Total: " + report.TotalSum);
                // Console.WriteLine("------------------------------------------");
            }
        }
    }
}
