using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIT.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogId { get; set; }

        public string Category { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        public string Signature { get; set; }
    }
}
