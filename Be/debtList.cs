//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Be
{
    using System;
    using System.Collections.Generic;
    
    public partial class debtList
    {
        public int id { get; set; }
        public Nullable<int> person { get; set; }
        public Nullable<long> debt { get; set; }
    
        public virtual beAddAthlete beAddAthlete { get; set; }
    }
}
