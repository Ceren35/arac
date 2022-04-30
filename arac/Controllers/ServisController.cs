using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using arac.Models;
using arac.ViewModel;

namespace arac.Controllers
{
    public class ServisController : ApiController
    {
        Database1Entities db = new Database1Entities();
        SonucModel sonuc = new SonucModel();

        #region Kullanici
        [HttpGet]
        [Route("api/kullaniciliste")]
        public List<KullaniciModel> KullaniciListe()
        {
            List<KullaniciModel> liste = db.KullaniciTable.Select(x => new KullaniciModel()
            {
                KullaniciId = x.KullaniciId,
                AdSoyad = x.AdSoyad,
                KullaniciAdi = x.KullaniciAdi,
                Sifre = x.Sifre,
                Adres = x.Adres,
                TelefonNo = x.TelefonNo,
                Email = x.Email,
                KayitTarihi = x.KayitTarihi,
                KullaniciYetki = x.KullaniciYetki,
                FavoriId = x.FavoriId,
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/kullanicibyid/{kullaniciId}")]
        public KullaniciModel KullaniciById(int kullaniciId)
        {
            KullaniciModel kayit = db.KullaniciTable.Where(s => s.KullaniciId == kullaniciId).Select(x => new KullaniciModel()
            {
                KullaniciId = x.KullaniciId,
                AdSoyad = x.AdSoyad,
                KullaniciAdi = x.KullaniciAdi,
                Sifre = x.Sifre,
                Adres = x.Adres,
                TelefonNo = x.TelefonNo,
                Email = x.Email,
                KayitTarihi = x.KayitTarihi,
                KullaniciYetki = x.KullaniciYetki,
                FavoriId = x.FavoriId,
            }).FirstOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/kullaniciekle")]
        public SonucModel KullaniciEkle(KullaniciModel model)
        {
            if (db.KullaniciTable.Count(s => s.KullaniciId == model.KullaniciId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kullanıcı Adı Kayıtlıdır!";
                return sonuc;
            }
            KullaniciTable yeni = new KullaniciTable();
            yeni.KullaniciId = model.KullaniciId;
            db.KullaniciTable.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/kullaniciduzenle")]
        public SonucModel KullanıcıDuzenle(KullaniciModel model)
        {
            KullaniciTable kayit = db.KullaniciTable.Where(s => s.KullaniciId == model.KullaniciId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.KullaniciId = model.KullaniciId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/kullanicisil/{KullaniciId}")]
        public SonucModel KullaniciId(int KullaniciId)
        {
            KullaniciTable kayit = db.KullaniciTable.Where(s => s.KullaniciId == KullaniciId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.KullaniciTable.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Silindi";
            return sonuc;
        }
        #endregion

        #region Kategori
        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.KategoriTable.Select(x => new KategoriModel()
            {
                KategoriId = x.KategoriId,
                KategoriAdi = x.KategoriAdi,
                KategoriUrunSay = x.IlanTable.Count()
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/kategoribyid/{katId}")]
        public KategoriModel KategoriById(int katId)
        {
            KategoriModel kayit = db.KategoriTable.Where(s => s.KategoriId == katId).Select(x => new KategoriModel()
            {
                KategoriId = x.KategoriId,
                KategoriAdi = x.KategoriAdi,
                KategoriUrunSay = x.IlanTable.Count()
            }).FirstOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.KategoriTable.Count(s => s.KategoriAdi == model.KategoriAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kategori Adı Kayıtlıdır!";
                return sonuc;
            }
            KategoriTable yeni = new KategoriTable();
            yeni.KategoriAdi = model.KategoriAdi;
            db.KategoriTable.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            KategoriTable kayit = db.KategoriTable.Where(s => s.KategoriId == model.KategoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.KategoriAdi = model.KategoriAdi;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/kategorisil/{katId}")]
        public SonucModel KategoriSil(int katId)
        {
            KategoriTable kayit = db.KategoriTable.Where(s => s.KategoriId == katId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            if (db.IlanTable.Count(s => s.IlanId == katId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Ürün Kaydı Olan Kategori Silinemez!";
                return sonuc;
            }
            db.KategoriTable.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";
            return sonuc;
        }
        #endregion

        #region Detay
        [HttpGet]
        [Route("api/detayliste")]
        public List<DetayModel> DetayListe()
        {
            List<DetayModel> liste = db.DetayTable.Select(x => new DetayModel()
            {
                DetayId = x.DetayId,
                Marka = x.Marka,
                Model = x.Model,
                Yil = x.Yil,
                Renk = x.Renk,
                Plaka = x.Plaka,
                YakitTuru = x.YakitTuru,
                Ucret = x.Ucret,
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/detaylistebykatid/{katId}")]
        public List<DetayModel> DetayListByKatId(int katId)
        {
            List<DetayModel> liste = db.DetayTable.Where(s => s.DetayId == katId).Select(x => new DetayModel()
            {
                DetayId = x.DetayId,
                Marka = x.Marka,
                Model = x.Model,
                Yil = x.Yil,
                Renk = x.Renk,
                Plaka = x.Plaka,
                YakitTuru = x.YakitTuru,
                Ucret = x.Ucret,
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/detaybyid/{detayId}")]
        public DetayModel DetayById(int detayId)
        {
            DetayModel kayit = db.DetayTable.Where(s => s.DetayId == detayId).Select(x => new DetayModel()
            {
                DetayId = x.DetayId,
                Marka = x.Marka,
                Model = x.Model,
                Yil = x.Yil,
                Renk = x.Renk,
                Plaka = x.Plaka,
                YakitTuru = x.YakitTuru,
                Ucret = x.Ucret,
            }).FirstOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/detayekle")]
        public SonucModel DetayEkle(DetayModel model)
        {
            DetayTable yeni = new DetayTable();
            yeni.Marka = model.Marka;
            yeni.Model = model.Model;
            yeni.Yil = model.Yil;
            yeni.Renk = model.Renk;
            yeni.Plaka = model.Plaka;
            yeni.YakitTuru = model.YakitTuru;
            yeni.Ucret = model.Ucret;
            db.DetayTable.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Detay Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/detayduzenle")]
        public SonucModel DetayDuzenle(DetayModel model)
        {
            DetayTable kayit = db.DetayTable.Where(s => s.DetayId == model.DetayId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.DetayId = model.DetayId;
            kayit.Marka = model.Marka;
            kayit.Model = model.Model;

            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Detay Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/detaysil/{detayId}")]
        public SonucModel DetaySil(int DetayId)
        {
            DetayTable kayit = db.DetayTable.Where(s => s.DetayId == DetayId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.DetayTable.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Detay Silindi";
            return sonuc;
        }
        #endregion

        #region Ilan
        [HttpGet]
        [Route("api/ilanliste")]
        public List<IlanModel> ilanliste()
        {
            List<IlanModel> liste = db.IlanTable.Select(x => new IlanModel()
            {
                IlanId = x.IlanId,
                Baslik = x.Baslik,
                KategoriId = x.KategoriId,
                AlisTarihi = x.AlisTarihi,
                TeslimTarihi = x.TeslimTarihi,
                Kimden = x.Kimden,
                Adres = x.Adres,
                DetayId = x.DetayId,
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/ilanbyid/{ilanId}")]
        public List<IlanModel> IlanById(int IlanId)
        {
            List<IlanModel> kayit = db.IlanTable.Where(s => s.IlanId == IlanId).Select(x => new IlanModel()
            {
                IlanId = x.IlanId,
                Baslik = x.Baslik,
                KategoriId = x.KategoriId,
                AlisTarihi = x.AlisTarihi,
                TeslimTarihi = x.TeslimTarihi,
                Kimden = x.Kimden,
                Adres = x.Adres,
                DetayId = x.DetayId,
            }).ToList();
            return kayit;
        }

        [HttpPost]
        [Route("api/ilanekle")]
        public SonucModel ilanEkle(IlanModel model)
        {
            if (db.IlanTable.Count(s => s.IlanId == model.IlanId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen İlan Adı Kayıtlıdır!";
                return sonuc;
            }
            IlanTable yeni = new IlanTable();
            yeni.IlanId = model.IlanId;
            db.IlanTable.Add(yeni);

            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İlan Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/ilanduzenle")]
        public SonucModel IlanDuzenle(IlanModel model)
        {
            IlanTable kayit = db.IlanTable.Where(s => s.IlanId == model.IlanId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.IlanId = model.IlanId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İlan Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/ilansil/{IlanId}")]
        public SonucModel IlanSil(int IlanId)
        {
            IlanTable kayit = db.IlanTable.Where(s => s.IlanId == IlanId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            if (db.IlanTable.Count(s => s.IlanId == IlanId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Ürün Kaydı Olan İlan Silinemez!";
                return sonuc;
            }
            db.IlanTable.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İlan Silindi";
            return sonuc;
        }
        #endregion

        #region Favori
        [HttpGet]
        [Route("api/favoriliste")]
        public List<FavoriModel> FavoriListe()
        {
            List<FavoriModel> liste = db.FavoriTable.Select(x => new FavoriModel()
            {
                FavoriId = x.FavoriId,
                IlanId = x.IlanId,
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/favoribyid/{favoriId}")]
        public FavoriModel FavoriById(int FavoriId)
        {
            FavoriModel kayit = db.FavoriTable.Where(s => s.FavoriId == FavoriId).Select(x => new FavoriModel()
            {
                FavoriId = x.FavoriId,
                IlanId = x.IlanId,
            }).FirstOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/favoriekle")]
        public SonucModel FavoriEkle(FavoriModel model)
        {
            if (db.FavoriTable.Count(s => s.FavoriId == model.FavoriId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Favori Adı Kayıtlıdır!";
                return sonuc;
            }
            FavoriTable yeni = new FavoriTable();
            yeni.FavoriId = model.FavoriId;
            db.FavoriTable.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Favori Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/favoriduzenle")]
        public SonucModel FavoriDuzenle(FavoriModel model)
        {
            FavoriTable kayit = db.FavoriTable.Where(s => s.FavoriId == model.FavoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.FavoriId = model.FavoriId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Favori Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/favorisil/{FavoriId}")]
        public SonucModel FavoriSil(int FavoriId)
        {
            FavoriTable kayit = db.FavoriTable.Where(s => s.FavoriId == FavoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.FavoriTable.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Favori Silindi";
            return sonuc;
        }
        #endregion

        #region Sipariş
        [HttpGet]
        [Route("api/siparişliste")]
        public List<SiparisModel> SiparisListe()
        {
            List<SiparisModel> liste = db.SiparisTable.Select(x => new SiparisModel()
            {
                SiparisId = x.SiparisId,
                IlanId = x.IlanId,
                Adet = x.Adet,
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/siparisbyid/{siparisId}")]
        public SiparisModel SiparisById(int SiparisId)
        {
            SiparisModel kayit = db.SiparisTable.Where(s => s.SiparisId == SiparisId).Select(x => new SiparisModel()
            {
                SiparisId = x.SiparisId,
                IlanId = x.IlanId,
                Adet = x.Adet,
            }).FirstOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/siparisekle")]
        public SonucModel SiparisEkle(SiparisModel model)
        {
            if (db.SiparisTable.Count(s => s.SiparisId == model.SiparisId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Sipariş Adı Kayıtlıdır!";
                return sonuc;
            }
            SiparisTable yeni = new SiparisTable();
            yeni.SiparisId = model.SiparisId;
            db.SiparisTable.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sipariş Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/siparisduzenle")]
        public SonucModel SiparisDuzenle(SiparisModel model)
        {
            SiparisTable kayit = db.SiparisTable.Where(s => s.SiparisId == model.SiparisId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.SiparisId = model.SiparisId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sipariş Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/siparissil/{SiparisId}")]
        public SonucModel SiparisSil(int SiparisId)
        {
            SiparisTable kayit = db.SiparisTable.Where(s => s.SiparisId == SiparisId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.SiparisTable.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sipariş Silindi";
            return sonuc;
        }
        #endregion

    }
}
    

