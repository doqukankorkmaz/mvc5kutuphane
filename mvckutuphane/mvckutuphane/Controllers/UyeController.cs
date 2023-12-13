using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace mvckutuphane.Controllers
{
    public class UyeController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Uye
        public ActionResult Index(int sayfa=1)//default olarak hangi sayfadan başladığının ögsterir
        {
            //var degerler = db.TBLUYELER.ToList();
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3);//sayfadan başlayıp 3 üye gösterir
            return View(degerler);
        }
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER  P)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(P);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var ktg = db.TBLUYELER.Find(p.ID);
            ktg.AD = p.AD;
            ktg.SOYAD = p.SOYAD;
            ktg.MAIL= p.MAIL;
            ktg.KULLANICIADI= p.KULLANICIADI;
            ktg.SIFRE= p.SIFRE;
            ktg.OKUL= p.OKUL;
            ktg.TELEFON= p.TELEFON;
            ktg.FOTOGRAF= p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}