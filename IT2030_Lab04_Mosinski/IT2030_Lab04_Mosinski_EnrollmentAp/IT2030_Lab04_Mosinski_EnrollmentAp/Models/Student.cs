using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT2030_Lab04_Mosinski_EnrollmentAp.Models
{
    public class Student
    {
        public virtual int StudentID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
    }
}