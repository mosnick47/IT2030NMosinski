using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IT2030_Lab06_Mosinski_EnrollmentAp.Models
{
    public class Course
    {
        public virtual int CourseId { get; set; }

        [Display(Name = "Course Title")]
        // Had to comment these out
        //[Required(ErrorMessage = "Course Title cannot be blank")]
        //[Range(0, 150, ErrorMessage = "Course title cannot be greater than 150")]
        public virtual string CourseTitle { get; set; }

        [Display(Name = "Description")]
        public virtual string CourseDescription { get; set; }

        [Display(Name = "Number of Credits")]
        // Had to comment these out
        //[Required(ErrorMessage = "Number of Credits cannot be blank")]
        //[Range(1, 4, ErrorMessage = "Number of credits must be between 1 and 4")]
        public virtual int CourseCredits { get; set; }
    }
}