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
    
    public partial class FavoriTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FavoriTable()
        {
            this.KullaniciTable = new HashSet<KullaniciTable>();
        }
    
        public int FavoriId { get; set; }
        public Nullable<int> IlanId { get; set; }
    
        public virtual IlanTable IlanTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciTable> KullaniciTable { get; set; }
    }
}
