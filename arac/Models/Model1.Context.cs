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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database1Entities : DbContext
    {
        public Database1Entities()
            : base("name=Database1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DetayTable> DetayTable { get; set; }
        public virtual DbSet<FavoriTable> FavoriTable { get; set; }
        public virtual DbSet<IlanTable> IlanTable { get; set; }
        public virtual DbSet<KategoriTable> KategoriTable { get; set; }
        public virtual DbSet<KullaniciTable> KullaniciTable { get; set; }
        public virtual DbSet<SiparisTable> SiparisTable { get; set; }
    }
}
