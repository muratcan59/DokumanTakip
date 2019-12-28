using DokumanTakip.BII;
using DokumanTakip.Filters;
using DokumanTakip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokumanTakip.Controllers
{
    public class SurecController : Controller
    {
        [AdminLoginFilter]
        public ActionResult AktifSurec()
        {
            SurecRepository repo = new SurecRepository();
            var sonuc = repo.GetByFilter(x => x.AktifMi == false).ToList();
            return View(sonuc);
        }
        [AdminLoginFilter]
        public ActionResult AylikSurec()
        {
            SurecRepository repo = new SurecRepository();
            var month = DateTime.Now.AddMonths(-1);
            var sonuc = repo.GetByFilter(x => x.SonTamamlanmaTarih >= month && x.AktifMi == false).ToList();
            return View(sonuc);
        }
        [AdminLoginFilter]
        public ActionResult DevredilenIs()
        {
            SurecRepository repo = new SurecRepository();
            var sonuc = repo.GetByFilter(x => x.AktifMi == true).ToList();
            return View(sonuc);
        }
        [AdminLoginFilter]
        [HttpGet]
        public ActionResult SurecEkle()
        {
            IsRepository rep = new IsRepository();
            var isler = rep.GetByFilter(x => x.AktifMi == false).ToList();
            ViewBag.Isler = isler;
            //SurecRepository repo = new SurecRepository();
            //var sonuc = repo.GetByFilter(x => x.AktifMi == false).ToList();
            //ViewBag.Surecler = sonuc;
            return View();
        }

        [HttpPost]
        public ActionResult SurecEkle(Surec model)
        {
            model.AktifMi = false;
            model.KayitTarihi = DateTime.Now;
            SurecRepository repo = new SurecRepository();
            bool sonuc = repo.Add(model);
            TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Süreç eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Süreç eklenemedi." } };
            return RedirectToAction(nameof(SurecEkle));
        }
        [AdminLoginFilter]
        [HttpGet]
        public ActionResult SurecDuzenle(int id)
        {
            IsRepository rep = new IsRepository();
            var isler = rep.GetByFilter(x => x.AktifMi == false).ToList();
            ViewBag.Isler = isler;
            SurecRepository repo = new SurecRepository();
            var sonuc = repo.GetById(id);            
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult SurecDuzenle(Surec model)
        {
            model.AktifMi = false;
            model.KayitTarihi = DateTime.Now;
            SurecRepository repo = new SurecRepository();
            var sonuc = repo.Update(model);
            //TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Süreç düzenlendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Süreç düzenlemedi." } };
            return RedirectToAction(nameof(AktifSurec));
        }

        public ActionResult SurecSil(int id)
        {
            SurecRepository repo = new SurecRepository();
            bool sonuc = repo.SoftDelete(id);
            //TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Süreç silindi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Süreç silinemedi." } };
            return RedirectToAction(nameof(AktifSurec));
        }
    }
}