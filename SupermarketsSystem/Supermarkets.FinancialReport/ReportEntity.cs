using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLData;

namespace Supermarkets.FinancialReport
{
    public class ReportEntity
    {
        public string Vendor { get; set; }

        public decimal Income { get; set; }

        public decimal Expense { get; set; }

        public decimal TotalTaxes { get; set; }

        public decimal FinalResult { get; set; }
    }
}
