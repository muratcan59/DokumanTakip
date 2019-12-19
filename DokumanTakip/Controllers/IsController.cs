﻿using DokumanTakip.BII;
using DokumanTakip.Filters;
using DokumanTakip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokumanTakip.Controllers
{
    public class IsController : Controller
    {
        [AdminLoginFilter]
        public ActionResult AcilIsler()
        {
            IsRepository repo = new IsRepository();
            var sonuc = repo.GetByFilter(x => x.CozumTarihi.Day == (DateTime.Now.Day - 7)).ToList();
            return View(sonuc);
        }
        public ActionResult NormalIsler()
        {
            IsRepository repo = new IsRepository();
            var sonuc = repo.GetByFilter(x => x.AktifMi == false).ToList();
            return View(sonuc);
        }
        public ActionResult TamamlanmisIsler()
        {
            IsRepository repo = new IsRepository();
            var sonuc = repo.GetByFilter(x => x.CozumTarihi >= DateTime.Now).ToList();
            return View(sonuc);
        }

        [HttpGet]
        public ActionResult IsEkle()
        {
            IsRepository repo = new IsRepository();
            var sonuc = repo.GetByFilter(x => x.AktifMi == false).ToList();
            ViewBag.Isler = sonuc;
            return View();
        }

        [HttpPost]
        public ActionResult IsEkle(Is model)
        {
            model.AktifMi = false;
            model.KayitTarihi = DateTime.Now;
            IsRepository repo = new IsRepository();
            bool sonuc = repo.Add(model);
            TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "İş eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "İş eklenemedi." } };
            return RedirectToAction(nameof(IsEkle));
        }

        [HttpGet]
        public ActionResult IsDuzenle(int id)
        {
            IsRepository repo = new IsRepository();
            ViewBag.Isler = repo.GetByFilter(x => x.AktifMi == false).ToList();
            var sonuc = repo.GetById(id);
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult IsDuzenle(Is model)
        {
            IsRepository repo = new IsRepository();
            var sonuc = repo.Update(model);
            return RedirectToAction(nameof(NormalIsler));
        }

        public ActionResult IsSil(int id)
        {
            IsRepository repo = new IsRepository();
            bool sonuc = repo.SoftDelete(id);            
            return RedirectToAction(nameof(NormalIsler));
        }
    }
}