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
    
    public partial class Admission
    {
        public int AdmissionId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string StudentName { get; set; }
        public string GuardianName { get; set; }
        public string GuardianType { get; set; }
        public string ContactNo { get; set; }
        public string PreviousEduDetails { get; set; }
        public string PhotoUpload { get; set; }
        public string AttachedDoc { get; set; }
        public string Status { get; set; }
        public string Class { get; set; }
        public Nullable<int> AcademicYear { get; set; }
    }
}
