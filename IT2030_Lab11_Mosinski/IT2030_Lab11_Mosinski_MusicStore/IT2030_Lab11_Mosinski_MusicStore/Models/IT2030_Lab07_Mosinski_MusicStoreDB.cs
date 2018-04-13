using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT2030_Lab04_Mosinski_MusicStore.Models
{
    public class IT2030_Lab07_Mosinski_MusicStoreDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    

        // We want to change the behavior so that everytime we call the application, it drops the tables
        // and creates new and fresh tables. Really useful for testing!
        public IT2030_Lab07_Mosinski_MusicStoreDB() : base("name=IT2030_Lab04_Mosinski_MusicStoreDB")
        {

        }

        public System.Data.Entity.DbSet<IT2030_Lab04_Mosinski_MusicStore.Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<IT2030_Lab04_Mosinski_MusicStore.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<IT2030_Lab04_Mosinski_MusicStore.Models.Genre> Genres { get; set; }
        public System.Data.Entity.DbSet<IT2030_Lab04_Mosinski_MusicStore.Models.Cart> Carts { get; set; }
    }
}
