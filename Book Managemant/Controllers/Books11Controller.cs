using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book_Managemant.Models;

namespace Book_Managemant.Controllers
{
    public class Books11Controller : Controller
    {
        private Book_MngEntities1 db = new Book_MngEntities1();

        // GET: Books11
        public ActionResult Index()
        {
            var books1 = db.Books1.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            return View(books1.ToList());
        }

        // GET: Books11/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books1 books1 = db.Books1.Find(id);
            if (books1 == null)
            {
                return HttpNotFound();
            }
            return View(books1);
        }

        // GET: Books11/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            return View();
        }

        // POST: Books11/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,PublishedYear,ISBN,AuthorID,CategoryID,PublisherID")] Books1 books1)
        {
            if (ModelState.IsValid)
            {
                db.Books1.Add(books1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", books1.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", books1.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", books1.PublisherID);
            return View(books1);
        }

        // GET: Books11/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books1 books1 = db.Books1.Find(id);
            if (books1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", books1.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", books1.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", books1.PublisherID);
            return View(books1);
        }

        // POST: Books11/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,PublishedYear,ISBN,AuthorID,CategoryID,PublisherID")] Books1 books1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", books1.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", books1.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", books1.PublisherID);
            return View(books1);
        }

        // GET: Books11/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books1 books1 = db.Books1.Find(id);
            if (books1 == null)
            {
                return HttpNotFound();
            }
            return View(books1);
        }

        // POST: Books11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books1 books1 = db.Books1.Find(id);
            db.Books1.Remove(books1);
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
