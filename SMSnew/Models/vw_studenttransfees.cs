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
    
    public partial class vw_studenttransfees
    {
        public string StudFirstName { get; set; }
        public string StudLastName { get; set; }
        public int TransportationId { get; set; }
        public Nullable<int> TransportationFeesId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> AccYear { get; set; }
        public Nullable<int> Status { get; set; }
        public string VehicleType { get; set; }
        public string TransportFrom { get; set; }
        public string TransportTo { get; set; }
        public string StudDivision { get; set; }
        public string StudClass { get; set; }
    }
}
