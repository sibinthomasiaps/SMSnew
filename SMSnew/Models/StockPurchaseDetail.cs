//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMSnew.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockPurchaseDetail
    {
        public int SPDetailId { get; set; }
        public Nullable<int> StockPurchaseId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<decimal> ItemRate { get; set; }
        public Nullable<decimal> ItemQuantity { get; set; }
        public Nullable<decimal> ItemAmount { get; set; }
        public string ItemName { get; set; }
    }
}
