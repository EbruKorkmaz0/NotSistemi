using NotSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotSistemi.Controllers
{
    public class HomeController : Controller
    {
      
            public ActionResult Index()
            {
                MvcContext db = new MvcContext();
                List<Ogrenci> ogrenciler = db.Ogrenci.ToList();
                return View(ogrenciler);
                MvcContext mvcContext = new MvcContext();   
                List<Notlar> notlar = mvcContext.Notlar.ToList();
                return View(notlar);

        }


      }
}