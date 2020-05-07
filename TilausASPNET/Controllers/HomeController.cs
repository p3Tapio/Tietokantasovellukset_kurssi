using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TilausASPNET.Models;

namespace TilausASPNET.Controllers {
    public class HomeController : Controller {
        TilausDBEntities db = new TilausDBEntities();
        public ActionResult Index() {

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
        public ActionResult Authorize(Logins LoginModel)
        {


            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);

            if (LoggedUser != null)
            {

                ViewBag.LoginMessage = "Successfull Login";
                ViewBag.LoggedStatus = "in";
                Session["UserName"] = LoggedUser.UserName;
                return RedirectToAction("Index");

            }
            else
            {

                ViewBag.LoginMessage = "Login unsuccessfull";
                ViewBag.LoggedStatus = "Out";
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana";
                ViewBag.LoginErrorMessage = LoginModel.LoginErrorMessage;  // Tsekkaa viestin näyttö ja korjaa kun Moodle toimii 
                return View("Login", LoginModel);
            }
        }
        public ActionResult LogOut()
        {

            Session.Abandon();
            ViewBag.LoggedStatus = "Out";
            return RedirectToAction("Index", "Home");
        }
    }
}