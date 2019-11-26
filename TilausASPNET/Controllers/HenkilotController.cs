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
    public class HenkilotController : Controller {
        private TilausDBEntities db = new TilausDBEntities();

        // GET: Henkilot
        public ActionResult Index() {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                return View(db.Henkilot.ToList());
            }
        }

        // GET: Henkilot/Details/5
        public ActionResult Details(int? id) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Henkilot henkilot = db.Henkilot.Find(id);
                if (henkilot == null) {
                    return HttpNotFound();
                }
                return View(henkilot);
            }
        }

        // GET: Henkilot/Create
        public ActionResult Create() {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero, Postinumero");
                return View();
            }
        }

        // POST: Henkilot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Henkilo_id,Etunimi,Sukunimi,Osoite,Esimies,Postinumero,Sahkoposti")] Henkilot henkilot) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid) {
                    db.Henkilot.Add(henkilot);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postitoimipaikka", henkilot.Postinumero);

                return View(henkilot);
            }
        }

        // GET: Henkilot/Edit/5
        public ActionResult Edit(int? id) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Henkilot henkilot = db.Henkilot.Find(id);
                if (henkilot == null) {
                    return HttpNotFound();
                }
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero", henkilot.Postinumero);

                return View(henkilot);

            }
        }

        // POST: Henkilot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Henkilo_id,Etunimi,Sukunimi,Osoite,Esimies,Postinumero,Sahkoposti")] Henkilot henkilot) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid) {
                    db.Entry(henkilot).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero", henkilot.Postinumero);

                return View(henkilot);
            }
        }

        // GET: Henkilot/Delete/5
        public ActionResult Delete(int? id) {
            if (Session["UserName"] == null) {
                ViewBag.LoggedStatus = "Out";
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Henkilot henkilot = db.Henkilot.Find(id);
                if (henkilot == null) {
                    return HttpNotFound();
                }
                return View(henkilot);
            }
        }

        // POST: Henkilot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {

            Henkilot henkilot = db.Henkilot.Find(id);
            db.Henkilot.Remove(henkilot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
