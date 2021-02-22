using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class CommentModel
    {
        public int UserID { get; set; } = 1;

        public int MovieID { get; set; }
        
        [Display(Name = "Comment")]
        [DataType(DataType.Text)]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Write an actual sentence")]
        [Required(ErrorMessage = "if you want to write a comment atleast write something")]
        public string Comment { get; set; }
    }
}