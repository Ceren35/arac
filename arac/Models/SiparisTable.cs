//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace arac.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SiparisTable
    {
        public int SiparisId { get; set; }
        public Nullable<int> IlanId { get; set; }
        public string Adet { get; set; }
    
        public virtual IlanTable IlanTable { get; set; }
    }
}