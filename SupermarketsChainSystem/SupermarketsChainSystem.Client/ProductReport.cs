using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketsChainSystem.Client
{
    public class ProductReport
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Sum { get; set; }
            
        public ProductReport(string ProductName, int Quantity, decimal UnitPrice, decimal Sum){
            
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.Sum = Sum;

        
        }

    }
}
