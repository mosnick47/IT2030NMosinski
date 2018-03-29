using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   // Use this to exclude field from the binding
using System.ComponentModel.DataAnnotations;    // Need to have this to change the display name of fields that are in the grid

namespace IT2030_Lab04_Mosinski_MusicStore.Models
{
    [Bind(Exclude = "AlbumId")]     // Will exclude this field when binding to the grid. This is more of a security feature. If the field is not bound and sent to the grid, it cannot be modified.
    public class Album
    {        
        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }

        [Display(Name = "Album Title")] // Change the display name of the property
        [Required(ErrorMessage = "Album Title cannot be blank")]
        public virtual string Title { get; set; }

        [Display(Name = "Album Price")] // Change the display name of the property
        [Required(ErrorMessage = "Album Price cannot be blank")]    // Says that the field is required; the user must enter a value
        [Range(0.01, 100.00, ErrorMessage = "Album price must be between $0.01 and $100.00")]   // validates the value entered by the user; must be between .01 and 100.00
        [DisplayFormat(DataFormatString = "{0:C}")]   // Format the display of the value. DOES NOT FORMAT THE TEXTBOX THAT THE USER USES TO ENTER VALUE
        public virtual decimal Price { get; set; }
        
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        [Display(Name = "Album Art URL")]
        public virtual string AlbumArtUrl { get; set; }
        public virtual string AdditionalInfo { get; set; }
        public virtual string CountryOfOrigin { get; set; }
        public virtual bool InStock { get; set; }

    }
}