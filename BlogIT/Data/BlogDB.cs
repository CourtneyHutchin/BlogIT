using BlogIT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIT.Data
{
    public class BlogDB
    {
        // Add
        public static async Task<BlogPost> Add(BlogPost blog, ApplicationDbContext context)
        {
            await context.AddAsync(blog);
            await context.SaveChangesAsync();

            return blog;
        }

        // Delete
        public async static Task Delete(BlogPost blog, ApplicationDbContext context)
        {
            await context.AddAsync(blog);
            context.Entry(blog).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        // Edit
        public static async Task<BlogPost> Edit(BlogPost blog, ApplicationDbContext context)
        {
            await context.AddAsync(blog);
            context.Entry(blog).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return blog;
        }

        // Get a list of all blog items
        public static async Task<List<BlogPost>> GetAllBlogItems(ApplicationDbContext context)
        {
            List<BlogPost> blog = await (from BlogPost in context.BlogPost
                                      select BlogPost).ToListAsync();
            return blog;

        }

        // Get blog post by id
        public static async Task<BlogPost> GetBlogPostById(int id, ApplicationDbContext context)
        {
            BlogPost blog = await (from BlogPost in context.BlogPost
                                   where BlogPost.BlogId == id
                                   select BlogPost).SingleOrDefaultAsync();

            return blog;
        }
    }
}
