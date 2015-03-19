using SQLData;

namespace ExportSQLDBToMySQlDB
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Supermarkets.ExportSQLDnToMySQLDb;

    public class SupermarketsDbMySql : DbContext
    {
        public SupermarketsDbMySql()
            : base("name=MySQLSupermarkets")
        {
        }

        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<MySqlProduct> Products { get; set; }
        public virtual DbSet<SupermarketSale> SupermarketSales { get; set; }
        public virtual DbSet<SupermarketProduct> SupermarketProducts { get; set; }
        public virtual DbSet<Supermarket> Supermarkets { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
    }
}
