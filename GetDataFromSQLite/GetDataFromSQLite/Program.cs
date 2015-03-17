namespace TestSqlite
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    class Program
    {
        static void Main()
        {
            try
            {
                var db = new SQLiteDatabase(@"..\..\ProductsTaxes.sqlite");
                DataTable table;
                String query = "select * from ProductTaxes";
                table = db.GetDataTable(query);

                List<ProductTax> ptList = new List<ProductTax>();

                foreach (DataRow r in table.Rows)
                {
                    var id = Convert.ToInt32(r["Id"]);
                    var name = r["Name"].ToString();
                    var tax = Convert.ToDouble(r["Tax"]);

                    ProductTax pt = new ProductTax(id, name, tax);
                    ptList.Add(pt);
                }

                foreach (var productTax in ptList)
                {
                    Console.WriteLine(productTax.Id + " --- " + productTax.Name + " --- " + productTax.Tax + "%");
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
            }


        }
    }
}
