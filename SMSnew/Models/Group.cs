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
    
    public partial class Group
    {
        public int Groupid { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public Nullable<int> GroupStatus { get; set; }
        public Nullable<System.DateTime> GroupCreatedDate { get; set; }
        public Nullable<System.DateTime> GroupModifiedDate { get; set; }
    }
}
