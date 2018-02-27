using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IT2030_Lab06_Mosinski_EnrollmentAp.Models
{
    public class Student
    {
        public virtual int StudentID { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name cannot be blank")]
        [Range(0, 50, ErrorMessage = "Last Name must between between 0 and 50 characters")]
        public virtual string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name cannot be blank")]
        [Range(0, 50, ErrorMessage = "First Name must between between 0 and 50 characters")]
        public virtual string FirstName { get; set; }
    }
}