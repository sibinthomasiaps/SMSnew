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
    
    public partial class Attendance
    {
        public int AttendanceID { get; set; }
        public string StudClass { get; set; }
        public string StudDivision { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<System.DateTime> AttendanceDate { get; set; }
        public string AttStatus { get; set; }
    }
}
