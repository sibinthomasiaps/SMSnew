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
    
    public partial class vw_ListStockItem
    {
        public string CategoryName { get; set; }
        public int ItemId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string ItemName { get; set; }
        public string ItemUnit { get; set; }
        public Nullable<double> ItemUnitPrice { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<double> ItemTaxPercentage { get; set; }
        public Nullable<double> ItemTaxAmount { get; set; }
    }
}