using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketsChainSystem.Client
{
    public class StoreReport
    {

        public string StoreName { get; set; }
        public decimal TotalSum { get; set; }
        public List<ProductReport> productReports = new List<ProductReport>();


        public void AddReport(ProductReport report)
        {
            this.productReports.Add(report);
        }
    }



}
