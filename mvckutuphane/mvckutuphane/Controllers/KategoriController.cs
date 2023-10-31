using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckutuphane.Models.Entity;
namespace mvckutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler=db.TBLKATEGORI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI P) 
        {
            db.TBLKATEGORI.Add(P);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var Kategori=db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(Kategori); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD=p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}