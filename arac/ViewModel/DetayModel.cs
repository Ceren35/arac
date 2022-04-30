using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace arac.ViewModel
{
    public class DetayModel
    {
        public int DetayId { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Yil { get; set; }
        public string Renk { get; set; }
        public string Plaka { get; set; }
        public string YakitTuru { get; set; }
        public string Ucret { get; set; }
    }
}