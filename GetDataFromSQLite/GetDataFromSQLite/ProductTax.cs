
namespace TestSqlite
{
    using System;

    public class ProductTax
    {
        public ProductTax(int id, string name, double tax)
        {
            this.Id = id;
            this.Name = name;
            this.Tax = tax;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Tax { get; set; }
    }
}
