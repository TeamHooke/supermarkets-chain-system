using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace SupermarketsChainSystem.Client
{
    public class ExcelManager
    {
        public ExcelManager()
        {
     
        }


        public StoreReport GetData(string pathToExcelFile)
        {
           // Console.WriteLine(pathToExcelFile);
            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathToExcelFile + ";Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sales$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    int counter = 0;
                    var storeReport = new StoreReport();
                    decimal total = 0;
                    string storeNameFromExcel = "";
                    while (dr.Read())
                    {
                        if (counter == 0)
                        {
                            storeNameFromExcel = dr[0].ToString();
                        }
                        else if (counter >= 2 && counter <= dr.FieldCount - 1)
                        {
                            var Product = dr[0].ToString();
                            int Quantity = int.Parse(dr[1].ToString());
                            var UnitPrice = decimal.Parse(dr[2].ToString());
                            var Sum = decimal.Parse(dr[3].ToString());
                            var product = new ProductReport(Product, Quantity, UnitPrice, Sum);
                            storeReport.AddReport(product);

                        }
                        else if (counter == dr.FieldCount)
                        {
                            total = decimal.Parse(dr[3].ToString());

                        }
                        counter++;
                    }

                    storeReport.StoreName = storeNameFromExcel;
                    storeReport.TotalSum = total;
                    return storeReport;
                }
            }

        }
    }
}
