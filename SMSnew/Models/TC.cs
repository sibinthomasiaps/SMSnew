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
    
    public partial class TC
    {
        public int TCid { get; set; }
        public Nullable<int> StudId { get; set; }
        public string ClassLastStudied { get; set; }
        public string GuardianName { get; set; }
        public string AnyPendingFees { get; set; }
        public Nullable<int> WorkingDays { get; set; }
        public Nullable<int> WorkingDaysPresent { get; set; }
        public string ExtraCurricular { get; set; }
        public Nullable<System.DateTime> TCApplicationDate { get; set; }
        public Nullable<System.DateTime> TCIssueDate { get; set; }
        public string ReasonForLeaving { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string ModifiedDescription { get; set; }
    }
}
