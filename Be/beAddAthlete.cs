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
    
    public partial class beAddAthlete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public beAddAthlete()
        {
            this.periodRegisters = new HashSet<periodRegister>();
            this.debtLists = new HashSet<debtList>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string codeMelli { get; set; }
        public string fatherName { get; set; }
        public Nullable<int> age { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<periodRegister> periodRegisters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<debtList> debtLists { get; set; }
    }
}