using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarkets.LoadXMLData;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var parser = new XMLParser("../../Sample-Vendor-Expenses.xml");
            parser.SaveExpensesDataToDB(this.textBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.SetOut(new TextBoxWriter(this.textBox1));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Report Between dates in format <MM.dd.yyyy>");

            if (this.startDate > this.endDate)
            {
                throw new ArgumentException("Start date is bigger than end date you looking for");
            }

            ToPDF.CreateAndStylePdf(startDate, endDate);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.startDate = dateTimePicker1.Value;
            this.IsStartDateSet = true;
            EnableButton();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.endDate = dateTimePicker2.Value;
            this.IsEndDateSet = true;
            EnableButton();
        }

        private void EnableButton()
        {
            if (this.IsStartDateSet && this.IsEndDateSet)
            {
                this.button3.Enabled = true;
            }
        }
    }
}
