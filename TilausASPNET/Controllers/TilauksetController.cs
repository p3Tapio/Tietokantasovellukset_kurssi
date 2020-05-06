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
    public class TilauksetController : Controller {
        private TilausDBEntities db = new TilausDBEntities();

        // GET: Tilaukset
        public ActionResult Index() {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                var tilaukset = db.Tilaukset.Include(t => t.Asiakkaat).Include(t => t.Postitoimipaikat);
                return View(tilaukset.ToList());
            }
        }

        // GET: Tilaukset/Details/5
        public ActionResult Details(int? id) {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tilaukset tilaukset = db.Tilaukset.Find(id);
                if (tilaukset == null) {
                    return HttpNotFound();
                }
                return View(tilaukset);
            }
        }

        // GET: Tilaukset/Create
        public ActionResult Create() {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "Nimi");
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero");
                return View();
            }
        }

        // POST: Tilaukset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TilausID,AsiakasID,Toimitusosoite,Postinumero,Tilauspvm,Toimituspvm")] Tilaukset tilaukset) {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid) {

                    db.Tilaukset.Add(tilaukset);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "Nimi", tilaukset.AsiakasID);
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero", tilaukset.Postinumero);
                return View(tilaukset);
            }
        }

        // GET: Tilaukset/Edit/5
        public ActionResult Edit(int? id) {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tilaukset tilaukset = db.Tilaukset.Find(id);
                if (tilaukset == null) {
                    return HttpNotFound();
                }
                ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "Nimi", tilaukset.AsiakasID);
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero", tilaukset.Postinumero);
                return View(tilaukset);
            }
        }

        // POST: Tilaukset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TilausID,AsiakasID,Toimitusosoite,Postinumero,Tilauspvm,Toimituspvm")] Tilaukset tilaukset) {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid) {
                    db.Entry(tilaukset).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "Nimi", tilaukset.AsiakasID);
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postitoimipaikka", tilaukset.Postinumero);
                return View(tilaukset);
            }
        }

        // GET: Tilaukset/Delete/5
        public ActionResult Delete(int? id) {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tilaukset tilaukset = db.Tilaukset.Find(id);
                if (tilaukset == null) {
                    return HttpNotFound();
                }
                return View(tilaukset);
            }
        }

        // POST: Tilaukset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            if (Session["UserName"] == null) {
                return RedirectToAction("login", "home");
            } else {
                ViewBag.LoggedStatus = "In";
                try {
                    Tilaukset tilaukset = db.Tilaukset.Find(id);
                    db.Tilaukset.Remove(tilaukset);
                    db.SaveChanges();
                    return RedirectToAction("Index");
#pragma warning disable CS0168 // Variable is declared but never used
                } catch (Exception ForeignKeyConstraint) {
#pragma warning restore CS0168 // Variable is declared but never used
                    return Content("<script language='javascript' type='text/javascript'>alert('Tilausrivit -taulussa olevaa tietoa ei voi poistaa');</script>");

                }

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
