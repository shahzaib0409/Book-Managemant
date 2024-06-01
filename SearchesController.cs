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
    public class SearchesController : Controller
    {
        private Book_MngEntities1 db = new Book_MngEntities1();

        // GET: Searches
        public ActionResult Index(string searchBy,string search)
        {
            if (searchBy == "Name")
            {
                return View(db.Searches.Where(x => x.Author.Name.StartsWith (search )|| search == null).ToList());
            }
            else 
            {
                return View(db.Searches.Where(x => x.Category.CategoryName.StartsWith( search) || search == null).ToList());

            }

            
        }
    

        // GET: Searches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // GET: Searches/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            return View();
        }

        // POST: Searches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookNum,AuthorID,CategoryID,PublisherID")] Search search)
        {
            if (ModelState.IsValid)
            {
                db.Searches.Add(search);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", search.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", search.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", search.PublisherID);
            return View(search);
        }

        // GET: Searches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", search.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", search.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", search.PublisherID);
            return View(search);
        }

        // POST: Searches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookNum,AuthorID,CategoryID,PublisherID")] Search search)
        {
            if (ModelState.IsValid)
            {
                db.Entry(search).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", search.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", search.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", search.PublisherID);
            return View(search);
        }

        // GET: Searches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searches.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // POST: Searches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Search search = db.Searches.Find(id);
            db.Searches.Remove(search);
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
