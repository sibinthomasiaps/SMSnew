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
    
    public partial class vw_IndexEvent
    {
        public int Expr1 { get; set; }
        public int EventRegID { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public string EventVenue { get; set; }
        public string EventLocation { get; set; }
        public string EventCountry { get; set; }
        public string EventDetails { get; set; }
        public string EventEmail { get; set; }
        public string EventPH { get; set; }
        public string EventFax { get; set; }
        public Nullable<int> EventParticipantsNumber { get; set; }
        public Nullable<int> EventInCharge { get; set; }
        public Nullable<System.DateTime> CheckInDate { get; set; }
        public Nullable<System.DateTime> CheckOutDate { get; set; }
        public string UploadFiles { get; set; }
        public string Status { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
    }
}
