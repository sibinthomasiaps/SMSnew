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
    
    public partial class Transportation
    {
        public int TransportationId { get; set; }
        public Nullable<int> TransportationFeesId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> AccYear { get; set; }
        public Nullable<int> Status { get; set; }
    }
}