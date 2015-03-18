using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFSalesReports;

namespace XMLParser
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            var parser = new XMLParser("../../Sample-Vendor-Expenses.xml");
            parser.SaveExpensesDataToDB();


            // pdf export
            Console.WriteLine("Report Between dates in format <MM.dd.yyyy>");
            Console.Write("First date: ");
            var startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Second date: ");
            var endDate = DateTime.Parse(Console.ReadLine());

            if (startDate > endDate)
            {
                throw new ArgumentException("Start date is bigger than end date you looking for");
            }

            ToPDF.CreateAndStylePdf(startDate, endDate);
            
            // mysql export
            MySQLExport.ConnectToMySQLDb();
            MySQLExport.FillDataIntoMySQLDb();
            MySQLExport.DisconnectFromMySQLDb();
        }
    }
}
