using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIT.Models
{
    public class BlogPost
    {
        public int BlogId { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Signature { get; set; }
    }
}
