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
    
    public partial class DebitCard
    {
        public int DebitCardId { get; set; }
        public string DebitCard1 { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> SwipeDateTime { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<double> BalanceAmount { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public string PINnumber { get; set; }
        public string UserType { get; set; }
        public string RechargeType { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> DebitCardStatus { get; set; }
    }
}