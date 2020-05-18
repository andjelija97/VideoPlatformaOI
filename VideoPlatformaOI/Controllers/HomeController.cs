using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoPlatformaOI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            OIVideoPlatformaDataContext oiVideo = new OIVideoPlatformaDataContext();
            if (fc["username"] != null && fc["pass"] != null)
            {
                string user = fc["username"];
                string pass = fc["pass"];

                Klijent k = (from c in oiVideo.Klijents
                             where c.Email.Equals(user) && c.Lozinka.Equals(pass)
                             select c).Single();
             Session["Klijent"] = k;
                if (k != null)
                {
                   
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Poruka = "Nema tog korisnika";
                    return View();
                }
            }
            else
            {
                ViewBag.Poruka = "Nema tog korisnika";
                return View();

            }
        }

        public ActionResult OdjaviSe()
        {
            Session["Klijent"] = null;
            return RedirectToAction("Login");
        }

       
    }

  
}
