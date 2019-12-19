using DokumanTakip.BII;
using DokumanTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokumanTakip.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            KullaniciRepository repo = new KullaniciRepository();
            var user = repo.Login(model.Email, model.Sifre);
            if (user != null)
            {
                Session["LoginUser"] = user;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["Mesaj"] = new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Email veya şifre hatalı!" } };
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["LoginUser"] = null;
            Session.Remove("LoginUser");
            return RedirectToAction("Login", "User");
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            KullaniciRepository repo = new KullaniciRepository();
            RolRepository rolRepo = new RolRepository();
            bool result = repo.Add(new Model.Kullanici { Ad = model.Ad, Sifre = model.Sifre, Soyad = model.Soyad, Email = model.Email, AktifMi = false, KayitTarihi = DateTime.Now, Telefon = model.Telefon });
            var userId = repo.GetByFilter(x => x.Email == model.Email).FirstOrDefault().Id;
            var roleId = rolRepo.GetByFilter(x => x.Ad == "Admin").FirstOrDefault().Id;
            repo.AddRole(userId, roleId);
            TempData["Mesaj"] = result ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt eklenemedi." } };
            return View();
        }
    }
}