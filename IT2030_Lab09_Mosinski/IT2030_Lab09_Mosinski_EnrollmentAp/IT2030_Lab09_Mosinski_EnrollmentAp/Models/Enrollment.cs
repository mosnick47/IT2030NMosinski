using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IT2030_Lab09_Mosinski_EnrollmentAp.Models
{
    public class Enrollment
    {
        public virtual int EnrollmentId { get; set; }
        public virtual int StudentId { get; set; }
        public virtual int CourseId { get; set; }

        [Required(ErrorMessage = "You must enter a grade.")]
        [RegularExpression(@"[A-F]")]   // Regular expression that says the grade must A, B, C, D, E, or F
        public virtual char Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual bool IsActive { get; set; }

        [Display(Name = "Assigned Campus")]
        [Required(ErrorMessage = "You must enter an assigned campus")]
        public virtual string AssignedCampus { get; set; }

        [Display(Name = "Enrolled in Semester")]
        [Required(ErrorMessage = "You must enter an enrolled semester")]
        public virtual string EnrollmentSemester { get; set; }

        [Required(ErrorMessage = "You must enter an enrollment year.")]
        // I am not sure the best way to do this. The upper limit is the maximum value that an int type can hold.
        [Range(2018, int.MaxValue, ErrorMessage = "Enrollment year must be greater than 2018")] 
        public virtual int EnrollmentYear { get; set; }
    }
}