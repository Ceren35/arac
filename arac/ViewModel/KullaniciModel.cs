using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace arac.ViewModel
{
    public class KullaniciModel
    {
        public int KullaniciId { get; set; }
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Email { get; set; }
        public string KayitTarihi { get; set; }
        public string KullaniciYetki { get; set; }
        public Nullable<int> FavoriId { get; set; }
    }
}