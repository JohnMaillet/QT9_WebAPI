using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QT9_WebForm.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public virtual int MovieID { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Invalid MovieID")]
        public virtual string MovieTitle { get; set; }
        [StringLength(5, MinimumLength = 0, ErrorMessage = "Invalid MovieTitle")]
        public virtual string MovieRating { get; set; }
        [Required]
        public virtual int ReleaseYear { get; set; }
        
    }
}
