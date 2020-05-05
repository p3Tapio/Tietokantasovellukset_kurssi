using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TilausASPNET.Models;


namespace TilausASPNET.Controllers
{
    public class PostitoimipaikatController : Controller
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private TilausDBEntities db = new TilausDBEntities();
#pragma warning restore IDE0044 // Add readonly modifier

        // GET: Postitoimipaikat
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                return View(db.Postitoimipaikat.ToList());
            }
        }

        // GET: Postitoimipaikat/Details/5
        public ActionResult Details(string id)
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
                Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
                if (postitoimipaikat == null)
                {
                    return HttpNotFound();
                }
                return View(postitoimipaikat);
            }
        }

        // GET: Postitoimipaikat/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                return View();
            }
        }

        // POST: Postitoimipaikat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Postinumero,Postitoimipaikka")] Postitoimipaikat postitoimipaikat)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";

                if (postitoimipaikat.Postinumero != null && postitoimipaikat.Postitoimipaikka != null)
                {
                    foreach (var x in db.Postitoimipaikat)
                    {
                        if (postitoimipaikat.Postinumero.Equals(x.Postinumero))
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        db.Postitoimipaikat.Add(postitoimipaikat);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

                return View(postitoimipaikat);
            }
        }

        // GET: Postitoimipaikat/Edit/5
        public ActionResult Edit(string id)
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
                Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
                if (postitoimipaikat == null)
                {
                    return HttpNotFound();
                }
                return View(postitoimipaikat);
            }
        }
        // POST: Postitoimipaikat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Postinumero,Postitoimipaikka")] Postitoimipaikat postitoimipaikat)
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
                    db.Entry(postitoimipaikat).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(postitoimipaikat);
            }
        }

        // GET: Postitoimipaikat/Delete/5
        public ActionResult Delete(string id)
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
                Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
                if (postitoimipaikat == null)
                {
                    return HttpNotFound();
                }
                return View(postitoimipaikat);
            }

        }
        // POST: Postitoimipaikat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggedStatus = "In";
                foreach (var postinro in db.Asiakkaat)
                {
                    if (postinro.Postinumero.Equals(id))
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Käytössä olevaa toimipaikkatietoa ei voi poistaa');</script>");
                    }
                }
                foreach (var tilaus in db.Tilaukset)
                {
                    if (tilaus.Postinumero.Equals(id))
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Käytössä olevaa toimipaikkatietoa ei voi poistaa');</script>");
                    }
                }

                Postitoimipaikat postitoimipaikat = db.Postitoimipaikat.Find(id);
                db.Postitoimipaikat.Remove(postitoimipaikat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
