using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TilausASPNET.Filtterit;
using TilausASPNET.Models;
using TilausASPNET.ViewModels;

namespace TilausASPNET.Controllers
{
    public class TilauksetController : Controller
    {
        private TilausDBEntities1 db = new TilausDBEntities1();

        // GET: Tilaukset
        public ActionResult Index(int? asiakasHaku)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                var tilaukset = db.Tilaukset.Include(t => t.Asiakkaat).Include(t => t.Postitoimipaikat);
                if (asiakasHaku != null && asiakasHaku != 0)
                {
                    tilaukset = tilaukset.Where(x => x.AsiakasID == asiakasHaku);
                }

                var asiakkaat = from x in db.Asiakkaat select x;
                var asikkaatSelectList = TilauksetFilters.AsiakkaatDropDownList(asiakkaat);

                ViewBag.Asiakas = new SelectList(asikkaatSelectList, "AsiakasID", "Nimi", asiakasHaku);

                return View(tilaukset.ToList());
            }
        }

        // GET: Tilaukset/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tilaukset tilaukset = db.Tilaukset.Find(id);
                if (tilaukset == null)
                {
                    return HttpNotFound();
                }
                return View(tilaukset);
            }
        }

        // GET: Tilaukset/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
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
        public ActionResult Create([Bind(Include = "TilausID,AsiakasID,Toimitusosoite,Postinumero,Tilauspvm,Toimituspvm")] Tilaukset tilaukset)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid)
                {

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
        //public ActionResult Edit(int? id)
        //{
        //    if (Session["UserName"] == null)
        //    {
        //        return RedirectToAction("login", "home");
        //    }
        //    else
        //    {
        //        ViewBag.LoggedStatus = "In";
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Tilaukset tilaukset = db.Tilaukset.Find(id);
        //        if (tilaukset == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "Nimi", tilaukset.AsiakasID);
        //        ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero", tilaukset.Postinumero);
        //        return View(tilaukset);
        //    }
        //}
        // POST: Tilaukset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TilausID,AsiakasID,Toimitusosoite,Postinumero,Tilauspvm,Toimituspvm")] Tilaukset tilaukset)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                if (ModelState.IsValid)
                {
                    db.Entry(tilaukset).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "Nimi", tilaukset.AsiakasID);
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postitoimipaikka", tilaukset.Postinumero);
                return View(tilaukset);
            }
        }
        public ActionResult _ModalEdit(int? id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tilaukset tilaukset = db.Tilaukset.Find(id);
                if (tilaukset == null)
                {
                    return HttpNotFound();
                }
                ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "Nimi", tilaukset.AsiakasID);
                ViewBag.Postinumero = new SelectList(db.Postitoimipaikat, "Postinumero", "Postinumero", tilaukset.Postinumero);
                return PartialView("_ModalEdit", tilaukset);
            }
        }


        // GET: Tilaukset/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Tilaukset tilaukset = db.Tilaukset.Find(id);
                if (tilaukset == null)
                {
                    return HttpNotFound();
                }
                return View(tilaukset);
            }
        }

        // POST: Tilaukset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                try
                {
                    Tilaukset tilaukset = db.Tilaukset.Find(id);
                    db.Tilaukset.Remove(tilaukset);
                    db.SaveChanges();
                    return RedirectToAction("Index");
#pragma warning disable CS0168 // Variable is declared but never used
                }
                catch (Exception ForeignKeyConstraint)
                {
#pragma warning restore CS0168 // Variable is declared but never used
                    return Content("<script language='javascript' type='text/javascript'>alert('Tilausrivit -taulussa olevaa tietoa ei voi poistaa');</script>");

                }

            }
        }
        public ActionResult OrderSummary()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";

                var orderSummary = from tilaus in db.Tilaukset
                                   join trivi in db.Tilausrivit on tilaus.TilausID equals trivi.TilausID
                                   join asiakas in db.Asiakkaat on tilaus.AsiakasID equals asiakas.AsiakasID
                                   join tuote in db.Tuotteet on trivi.TuoteID equals tuote.TuoteID
                                   join postitoimi in db.Postitoimipaikat on tilaus.Postinumero equals postitoimi.Postinumero
                                   // where, order by ? 
                                   select new OrderSummaryData
                                   {
                                       TilausID = tilaus.TilausID,
                                       TilausriviID = trivi.TilausriviID,
                                       TuoteID = (int)trivi.TuoteID,
                                       TuoteNimi = tuote.Nimi,
                                       Maara = (int)trivi.Maara,
                                       TilausAhinta = (float)trivi.Ahinta,
                                       ImageLink = tuote.ImageLink,
                                       AsiakasID = (int)tilaus.AsiakasID,
                                       AsiakasNimi = asiakas.Nimi,
                                       Toimitusosoite = tilaus.Toimitusosoite,
                                       Postinumero = tilaus.Postinumero,
                                       Postitoimipaikka = postitoimi.Postitoimipaikka,
                                       Tilauspvm = tilaus.Tilauspvm,
                                       Toimituspvm = tilaus.Toimituspvm

                                   };

                return View(orderSummary);
            }

        }
        public ActionResult TilausOtsikot()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                var tilaukset = db.Tilaukset.Include(x => x.Asiakkaat).Include(x => x.Postitoimipaikat);

                return View(tilaukset.ToList());
            }
        }
        public ActionResult _Tilausrivit(int? id)
        {
            System.Diagnostics.Debug.WriteLine("ID: " + id);
            var orderRowList = from tilaus in db.Tilaukset
                               join trivi in db.Tilausrivit on tilaus.TilausID equals trivi.TilausID
                               join asiakas in db.Asiakkaat on tilaus.AsiakasID equals asiakas.AsiakasID
                               join tuote in db.Tuotteet on trivi.TuoteID equals tuote.TuoteID
                               where tilaus.TilausID == id
                               select new OrderRows
                               {
                                   TilausID = tilaus.TilausID, 
                                   TilausriviID = trivi.TilausriviID,
                                   TuoteID = (int)trivi.TuoteID,
                                   TuoteNimi = tuote.Nimi,
                                   Maara = (int)trivi.Maara,
                                   TilausAhinta = (float)trivi.Ahinta,
                                   AsiakasID = (int)tilaus.AsiakasID
                               };

            return PartialView(orderRowList);

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
