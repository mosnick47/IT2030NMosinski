using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IT2030_FinalProject_Mosinski.Models
{
    [Table("EventTypes")]       // For some reason I was getting an error. I researched how to handle the error and it said to add this attribute
    public class EventTypes
    {
        [Key]
        public virtual int EventTypeID { get; set; }  // For some reason I was getting an error. I researched how to handle the error and it said to add this attribute
        public virtual string EventType { get; set; } 
    }
}