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
    
    public partial class Expens
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> Money { get; set; }
        public Nullable<int> VendorId { get; set; }
    
        public virtual Vendor Vendor { get; set; }
    }
}
