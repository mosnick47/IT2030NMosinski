using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT2030_Lab13_MovieStore.Models;

namespace IT2030_Lab13_MovieStore.Controllers
{
    public class MoviesController : Controller
    {
        private IT2030_Lab13_MovieStoreDbContext db = new IT2030_Lab13_MovieStoreDbContext();

        // Dependency Injection using constructor; It's call dependency injection because
        // this controller DEPENDS entirely on this DBContext. So we need to create a constructor
        // that will copy this DBContext to the the unit text when a MoviesController object gets created.
        // Will be used when the application is executed
        public MoviesController()
        {

        }

        // Will be used by the unit test
        public MoviesController(IT2030_Lab13_MovieStoreDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View();    // This method is returning a view here.
            // It could also return other things like a Redirect, Json, HTTP Error, a value
        }

        public ActionResult IndexRedirect(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Create", "HomeController");
        }

        public List<Movie> ListOfMovies()
        {
            List<Movie> list = new List<Movie>
            {
                new Movie{MovieId = 1, Title = "Terminator 1" },
                new Movie{MovieId = 2, Title = "Terminator 2"},
                new Movie{MovieId = 3, Title = "Terminator 3" }
            };
            return list;
        }

        public ActionResult ListFromDb()
        {            
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Title,YearReleased")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Title,YearReleased")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
