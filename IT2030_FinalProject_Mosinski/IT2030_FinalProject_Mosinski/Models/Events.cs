using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IT2030_FinalProject_Mosinski.Models
{
    [Table("Events")]
    public class Events
    {
        [Key]
        public virtual int EventID { get; set; }
        public virtual string EventTitle { get; set; }
        public virtual string EventDescription { get; set; }
        public virtual string StartDate { get; set; }
        public virtual TimeSpan StartTime { get; set; }
        public virtual string EndDate { get; set; }
        public virtual TimeSpan EndTime {get; set;}
        public virtual string EventLocation { get; set; }
        public virtual string EventType { get; set; }       // This will be a dropdown list that the user can select and event type from ***Create an 
        public virtual string OrganizationFirstName { get; set; }
        public virtual string OrganizerLastName { get; set; }
        public virtual string OrgananizerPhone { get; set; }
        public virtual string OrganizerEmail { get; set; }
        public virtual int MaxTickets { get; set; }
        public virtual int AvailableTickets { get; set; }
    }
}