using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QT9_WebAPI.Models
{
    public class tblMovie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "")]
        public string MovieTitle { get; set; }
        [StringLength(5, MinimumLength = 0, ErrorMessage = "")]
        public string MovieRating { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
    }
}
