using System.Linq;
using ExportSQLDBToMySQlDB;
using Supermarkets.Data;

namespace Supermarkets.ExportSQLDnToMySQLDb
{
    public static class SeedMySqlDb
    {
        public static void Seed()
        {
            SupermarketsEntities contextSql = new SupermarketsEntities();
            SupermarketsDbMySql contextMySql = new SupermarketsDbMySql();

            var vendors = contextSql.Vendors.ToList().Select(v => new Vendor
            {
                Id = v.Id,
                Name = v.Name
            }).ToList();

            var measures = contextSql.Measures.ToList().Select(measure => new Measure
            {
                Id = measure.Id,
                Name = measure.Name
            }).ToList();

            var products = contextSql.Products.ToList().Select(product => new MySqlProduct
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                VendorId = product.VendorId,
                MeasureId = product.MeasureId,
                Income = product.SupermarketProducts.Average(p => p.UnitPrice) - product.Price
            }).ToList();

            var expenses = contextSql.Expenses.ToList().Select(e => new Expens
            {
                Id = e.Id,
                Date = e.Date,
                Money = e.Money,
                VendorId = e.VendorId
            }).ToList();

            var supermarkets = contextSql.Supermarkets.ToList().Select(s => new Supermarket
            {
                Id = s.Id,
                Location = s.Location
            }).ToList();

            var supermarketProducts = contextSql.SupermarketProducts.ToList().Select(p => new SupermarketProduct
            {
                Id = p.Id,
                ProductId = p.ProductId,
                SupermarketId = p.SupermarketId,
                UnitPrice = p.UnitPrice
            }).ToList();

            var supermarketSales = contextSql.Supermarket_Sales.ToList().Select(s => new Supermarket_Sales
            {
                Id = s.Id,
                ProductId = s.ProductId,
                SupermarketId = s.SupermarketId,
                Date = s.Date,
                CountOfSales = s.CountOfSales
            }).ToList();

            contextMySql.Vendors.AddRange(vendors);
            contextMySql.Measures.AddRange(measures);
            contextMySql.Expenses.AddRange(expenses);
            contextMySql.Products.AddRange(products);
            contextMySql.SupermarketProducts.AddRange(supermarketProducts);
            contextMySql.Supermarkets.AddRange(supermarkets);
            contextMySql.SupermarketSales.AddRange(supermarketSales);

            contextMySql.SaveChangesAsync();
        }
    }
}
