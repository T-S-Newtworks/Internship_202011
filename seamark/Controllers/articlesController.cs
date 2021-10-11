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
  public class ArticlesController : Controller
  {
    private seamarkContext db = new seamarkContext();

    // GET: articles
    public ActionResult Index()
    {
      return View(db.articles.ToList());
    }

    public ActionResult GetHighlight()
    {      
      if (db.articles.Count() == 0)
      {
        return HttpNotFound();
      }
      article article = db.articles.First();
      return View(article);
    }

    public ActionResult CreateArticle()
    {

      return View();
    }

    // GET: articles/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      article article = db.articles.Find(id);
      if (article == null)
      {
        return HttpNotFound();
      }
      return View(article);
    }

    // GET: articles/Create
    public ActionResult Create()
    {
      return View();
    }

        // POST: articles/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Solveflag,Name,Deleteflag,Text,Highlightflag")] article article)
        {
            if (ModelState.IsValid)
            {
                article.Date = DateTime.Now;
                db.articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

      return View(article);
    }

    // GET: articles/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      article article = db.articles.Find(id);
      if (article == null)
      {
        return HttpNotFound();
      }
      return View(article);
    }

    // POST: articles/Edit/5
    // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
    // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Date,Solveflag,Name,Deleteflag,Text,Highlightflag")] article article)
    {
      if (ModelState.IsValid)
      {
        db.Entry(article).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(article);
    }

    // GET: articles/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      article article = db.articles.Find(id);
      if (article == null)
      {
        return HttpNotFound();
      }
      return View(article);
    }

    // POST: articles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      article article = db.articles.Find(id);
      db.articles.Remove(article);
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
