//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Supermarkets.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupermarketProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SupermarketId { get; set; }
        public decimal UnitPrice { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supermarket Supermarket { get; set; }
    }
}