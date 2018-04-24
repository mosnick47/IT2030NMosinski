using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT2030_Lab13_MovieStore.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int YearReleased { get; set; }
    }
}