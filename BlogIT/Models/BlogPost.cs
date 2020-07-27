using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIT.Models
{
    public class BlogPost
    {
        /// <summary>
        /// Unique Identifier for each blog
        /// </summary>
        [Key]
        public int BlogId { get; set; }

        /// <summary>
        /// The category of the blog
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The Title of the blog
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        /// <summary>
        /// The descripton or summary of the blog
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The main content of the blog
        /// </summary>
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        /// <summary>
        /// The signature on the blog
        /// </summary>
        public string Signature { get; set; }
    }
}
