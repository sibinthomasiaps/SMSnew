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
    
    public partial class HostelFeeStructure
    {
        public int HostelFeeStructureId { get; set; }
        public Nullable<int> HostelId { get; set; }
        public string HostelFeeMonth { get; set; }
        public Nullable<double> HostelFeeMonthlyFee { get; set; }
        public Nullable<int> HostelFeeYear { get; set; }
        public Nullable<System.DateTime> HostelFeeStartDate { get; set; }
        public Nullable<System.DateTime> HostelFeeDueDate { get; set; }
        public Nullable<int> HostelFeeFineId { get; set; }
        public string HostelFeeType { get; set; }
        public string HostelFeeDescription { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
