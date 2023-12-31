﻿using mvckutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvckutuphane.Controllers
{
    
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler=db.TBLHAREKET.Where(x=>x.ISLEMDURUM==false).ToList(); //işlem durumu false olan değerleri listeler
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET P)
        {
            db.TBLHAREKET.Add(P);
            db.SaveChanges();
            return View();
        }
        public ActionResult Odunciade (int id)
        {
            var odn = db.TBLHAREKET.Find(id);
            return View("Odunciade", odn);
        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk = db.TBLHAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}