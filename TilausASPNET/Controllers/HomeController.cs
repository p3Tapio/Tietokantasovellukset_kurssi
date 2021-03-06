﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TilausASPNET.Models;

namespace TilausASPNET.Controllers {
    public class HomeController : Controller {
        TilausDBEntities1 db = new TilausDBEntities1();
        public ActionResult Index() {

            ViewBag.LoginError = 0;

            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                

            } else {
                ViewBag.LoggedStatus = "In";
            }
            return View();
        }
        public ActionResult About() {
            ViewBag.Message = "Applikaation kuvaus";
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
            } else {
                ViewBag.LoggedStatus = "In";
            }
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Yhteystiedot";
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";

            } else {
                ViewBag.LoggedStatus = "In";
            }

            return View();
        }
        public ActionResult Map() {

            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";

            } else {
                ViewBag.LoggedStatus = "In";
            }
            return View();


        }
        public ActionResult Login() {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";

            } else {
                ViewBag.LoggedStatus = "In";
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorize(Logins LoginModel)
        {


            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);

            if (LoggedUser != null)
            {

                ViewBag.LoginMessage = "Successfull Login";
                ViewBag.LoggedStatus = "in";
                ViewBag.LoginError = 0;
                Session["UserName"] = LoggedUser.UserName;
                Session["LoginID"] = LoggedUser.LoginId;
                return RedirectToAction("Index", "Home");   

            }
            else
            {

                ViewBag.LoginMessage = "Login unsuccessfull";
                ViewBag.LoggedStatus = "Out";
                ViewBag.LoginError = 1; 
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana";
                ViewBag.LoginErrorMessage = LoginModel.LoginErrorMessage; 
                return View("Index", LoginModel);
            }
        }
        public ActionResult LogOut()
        {

            Session.Abandon();
            ViewBag.LoggedStatus = "Out";
            return RedirectToAction("Index", "Home");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
      
            base.Dispose(disposing);
        }
    }
}