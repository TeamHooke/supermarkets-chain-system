using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Supermarkets.Data;
using Supermarkets.LoadXMLData;
using Supermarkets.ToPDFExport;
using Supermarkets.ReportsExport;
using Supermarkets.ExportSQLDnToMySQLDb;
using Supermarkets.FinancialReport;

namespace Supermarkets.Client
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            //var parser = new XMLParser("../../Sample-Vendor-Expenses.xml");
            //parser.SaveExpensesDataToDB();


            //// pdf export
            //Console.WriteLine("Report Between dates in format <MM.dd.yyyy>");
            //Console.Write("First date: ");
            //var startDate = DateTime.Parse(Console.ReadLine());
            //Console.Write("Second date: ");
            //var endDate = DateTime.Parse(Console.ReadLine());

            //if (startDate > endDate)
            //{
            //    throw new ArgumentException("Start date is bigger than end date you looking for");
            //}

            //ToPDF.CreateAndStylePdf(startDate, endDate);

            //// json and xml export
            //var context = new SupermarketsEntities();

            //XMLExporter.WriteToXml(context, new DateTime(2014, 1, 1), new DateTime(2015, 12, 12));

            //JSONExporter.WriteToJSON(context, new DateTime(2014, 1, 1), new DateTime(2015, 12, 12));

            //try
            //{
            //    SeedMySqlDb.Seed();
            //}
            //catch (MySqlException)
            //{
            //    SeedMySqlDb.Seed();
            //}

            ExcelExporter.GenerateReport();
        }
    }
}
