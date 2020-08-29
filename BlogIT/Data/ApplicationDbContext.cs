using System;
using System.Collections.Generic;
using System.Text;
using BlogIT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogIT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Get Set Blogpost Model
        /// </summary>
        public DbSet<BlogIT.Models.BlogPost> BlogPost { get; set; }
    }
}
