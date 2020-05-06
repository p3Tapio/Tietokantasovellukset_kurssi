using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TilausASPNET.Models;

namespace TilausASPNET.Controllers {
    public class AsiakkaatController : Controller {
        private TilausDBEntities db = new TilausDBEntities();

        // GET: Asiakkaat
        public ActionResult Index() {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                var asiakkaat = db.Asiakkaat.Include(a => a.Postitoimipaikat);
                return View(db.Asiakkaat.ToList());
            }
        }

        // GET: Asiakkaat/Details/5
        public ActionResult Details(int? id) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
                if (asiakkaat == null) {
                    return HttpNotFound();
                }
                return View(asiakkaat);
            }
        }

        // GET: Asiakkaat/Create
        public ActionResult Create() {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero");
                return View();
            }

        }

        // POST: Asiakkaat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsiakasID,Nimi,Osoite,Postinumero")] Asiakkaat asiakkaat) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid) {
                    db.Asiakkaat.Add(asiakkaat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postitoimipaikka", asiakkaat.Postinumero);
                return View(asiakkaat);
            }
        }

        // GET: Asiakkaat/Edit/5
        public ActionResult Edit(int? id) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
                if (asiakkaat == null) {
                    return HttpNotFound();
                }
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero", asiakkaat.Postinumero);
                return View(asiakkaat);
            }
        }

        // POST: Asiakkaat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsiakasID,Nimi,Osoite,Postinumero")] Asiakkaat asiakkaat) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid) {
                    db.Entry(asiakkaat).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postitoimipaikka", asiakkaat.Postinumero);
                return View(asiakkaat);
            }
        }

        // GET: Asiakkaat/Delete/5
        public ActionResult Delete(int? id) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
                if (asiakkaat == null) {
                    return HttpNotFound();
                }
                return View(asiakkaat);
            }
        }

        // POST: Asiakkaat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {

            try {

                Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
                db.Asiakkaat.Remove(asiakkaat);
                db.SaveChanges();
                return RedirectToAction("Index");
#pragma warning disable CS0168 // Variable is declared but never used
            } catch (Exception ForeignKeyConstraint) {
#pragma warning restore CS0168 // Variable is declared but never used
                return Content("<script language='javascript' type='text/javascript'>alert('Käytössä olevaa tietoa ei voi poistaa');</script>");

            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
