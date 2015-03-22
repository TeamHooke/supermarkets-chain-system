using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Supermarkets.Data;
using Supermarkets.ExportSQLDnToMySQLDb;
using Supermarkets.FinancialReport;
using Supermarkets.LoadXMLData;
using Supermarkets.ReportsExport;
using Supermarkets.ToPDFExport;

namespace Supermarkets.ClientWF
{
    public partial class Form1 : Form
    {
        private DateTime startDate;
        private DateTime endDate;
        private bool IsStartDateSet = false;
        private bool IsEndDateSet = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.SetOut(new TextBoxWriter(this.outputTextBox));
        }

        private void importXML_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Importing XML...");
            var parser = new XMLParser("../../Sample-Vendor-Expenses.xml");
            parser.SaveExpensesDataToDB(this.outputTextBox);
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Generating PDF report...");
            Console.WriteLine("Report Between dates in format <MM.dd.yyyy>");

            if (this.startDate > this.endDate)
            {
                throw new ArgumentException("Start date is bigger than end date you looking for");
            }

            ToPDF.CreateAndStylePdf(startDate, endDate);
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            this.startDate = startDatePicker.Value;
            this.IsStartDateSet = true;
            EnableButton();
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            this.endDate = endDatePicker.Value;
            this.IsEndDateSet = true;
            EnableButton();
        }

        private void EnableButton()
        {
            if (this.IsStartDateSet && this.IsEndDateSet)
            {
                this.exportPDF.Enabled = true;
            }
        }

        private void exportXML_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Exporting XML sales...");
            var context = new SupermarketsEntities();

            XMLExporter.WriteToXml(context, new DateTime(2014, 1, 1), new DateTime(2015, 12, 12), this.outputTextBox);
        }

        private void exportJSONSales_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Exporting JSON sales...");
            var context = new SupermarketsEntities();

            JSONExporter.WriteToJSON(context, new DateTime(2014, 1, 1), new DateTime(2015, 12, 12), this.outputTextBox);
        }

        private void populateMySqlDb_Click(object sender, EventArgs e)
        {
            try
            {
                SeedMySqlDb.Seed(this.outputTextBox);
            }
            catch (MySqlException)
            {
                SeedMySqlDb.Seed(this.outputTextBox);
            }
        }

        private void exportExcel_Click(object sender, EventArgs e)
        {
            var excelExporter = new ExcelExporter(this.outputTextBox);
            excelExporter.GenerateReport();
        }
    }
}
