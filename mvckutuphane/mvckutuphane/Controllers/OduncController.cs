using mvckutuphane.Models.Entity;
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
            var degerler=db.TBLHAREKET.ToList();
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
    }
}