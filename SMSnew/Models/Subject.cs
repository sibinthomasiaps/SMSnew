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
    
    public partial class Subject
    {
        public int Subjectid { get; set; }
        public string SubjectName { get; set; }
        public string SubjectClass { get; set; }
        public string SubjectDivision { get; set; }
        public Nullable<System.DateTime> SubjectModifiedDate { get; set; }
        public Nullable<int> SubjectModifiedBy { get; set; }
        public string SubjectModifiedDescription { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
