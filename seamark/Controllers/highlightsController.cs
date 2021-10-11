using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seamark.Models;

namespace seamark.Controllers
{
    public class highlightsController : Controller
    {
        private seamarkContext db = new seamarkContext();

        // GET: highlights
        public ActionResult Index()
        {
            return View(db.highlights.ToList());
        }

        public ActionResult GetHighlight()
        {
            return View(db.highlights.First());
        }

        // GET: highlights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            highlights highlights = db.highlights.Find(id);
            if (highlights == null)
            {
                return HttpNotFound();
            }
            return View(highlights);
        }

        // GET: highlights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: highlights/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Name,Text,Deleteflag,Color")] highlights highlights)
        {
            if (ModelState.IsValid)
            {
                db.highlights.Add(highlights);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(highlights);
        }

        // GET: highlights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            highlights highlights = db.highlights.Find(id);
            if (highlights == null)
            {
                return HttpNotFound();
            }
            return View(highlights);
        }

        // POST: highlights/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Name,Text,Deleteflag,Color")] highlights highlights)
        {
            if (ModelState.IsValid)
            {
                db.Entry(highlights).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(highlights);
        }

        // GET: highlights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            highlights highlights = db.highlights.Find(id);
            if (highlights == null)
            {
                return HttpNotFound();
            }
            return View(highlights);
        }

        // POST: highlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            highlights highlights = db.highlights.Find(id);
            db.highlights.Remove(highlights);
            db.SaveChanges();
            return RedirectToAction("Index");
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
