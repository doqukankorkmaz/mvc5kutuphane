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
        public ActionResult KategoriEkle(TBLKATEGORI P) 
        {
            db.TBLKATEGORI.Add(P);
            db.SaveChanges();
            return View();
        }
    }
}