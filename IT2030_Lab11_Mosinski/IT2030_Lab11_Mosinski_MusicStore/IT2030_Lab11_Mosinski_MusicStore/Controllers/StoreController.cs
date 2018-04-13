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
    public class StoreController : Controller
    {
        private IT2030_Lab07_Mosinski_MusicStoreDB db = new IT2030_Lab07_Mosinski_MusicStoreDB();

        // GET: Store
        // Basing a lot of what I do in this method off of the Edit method in the StoreManagerController
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // List of Artists in this genre
            var artists = db.Albums.Where(a => a.GenreId == id);
            return View(artists.ToList());
        }

        public ActionResult Browse()
        {
            var genres = db.Genres.ToList();
            return View(genres);
        }

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
    }
}