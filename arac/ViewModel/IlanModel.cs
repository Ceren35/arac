using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace arac.ViewModel
{
    public class IlanModel
    {
        public int IlanId { get; set; }
        public string Baslik { get; set; }
        public Nullable<int> KategoriId { get; set; }
        public string AlisTarihi { get; set; }
        public string TeslimTarihi { get; set; }
        public Nullable<int> Kimden { get; set; }
        public string Adres { get; set; }
        public Nullable<int> DetayId { get; set; }
    }
}