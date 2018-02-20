using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT2030_Lab04_Mosinski_MusicStore.Models;

namespace IT2030_Lab04_Mosinski_MusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private IT2030_Lab04_Mosinski_MusicStoreDB db = new IT2030_Lab04_Mosinski_MusicStoreDB();

        // GET: StoreManager
        public ActionResult Index()
        {
            // The below LINQ query says "from the database context, get all the albums and include artist and genre"
            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);    // Says "from my database, give me all the albums and include artist and genre". 
            return View(albums.ToList());   // Data is sent to the view in the form of a list                               "Includes" is almost like a join in SQL.
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl,InStock,CountryOfOrigin")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl,InStock,CountryOfOrigin")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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

        public ActionResult Test()
        {
            var albums = db.Albums;

            // LINQ Query - can step through any IEnumerable object, NOT JUST DataBases

            var albumsByName = from a in albums
                              where a.Title == "Stormbringer"
                              select a;
            //===========    OR    ============
            //var albumsByName = albums.Where(x => x.Title == "StormBringer");  // LINQ Extension - this is the preferred way

            var albumsByArtist = from a in albums
                                where a.Artist.Name == "Chic"
                                select a;
            //===========    OR    ============
            //var albumsByArtist = albums.Where(x => x.Artist.Name == "Chic");  // LINQ Extension - this is the preferred way

            var albumsByGenre = from a in albums
                               where a.Genre.Name == "Classical"
                               select a;
            //===========    OR    ============
            //var albumsByGenre = albums.Where(x => x.Genre.Name == "Classical").OrderByDescending(x => x.Title);   // LINQ Extension - this is the preferred way

            // One way to send the query results to the view
            ViewBag.AlbumsByName = new SelectList(albumsByName, "AlbumId", "Title", albumsByName.First().AlbumId);      // (IEnumerable items, Unique Identifier, Display value, Default value)
                                                                                                                        // Take the first album in the and select it by album ID and set that as the default value.
            ViewBag.AlbumsByArtist = new SelectList(albumsByArtist, "AlbumID", "Title", albumsByArtist.First().AlbumId);
            ViewBag.AlbumsByGenre = new SelectList(albumsByGenre, "AlbumID", "Title", albumsByGenre.First().AlbumId);

            return View();                                                          
        }
    }
}
