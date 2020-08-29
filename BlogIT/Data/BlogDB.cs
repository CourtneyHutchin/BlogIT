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
        /// <summary>
        /// Add Blog Item to DB
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<BlogPost> Add(BlogPost blog, ApplicationDbContext context)
        {
            await context.AddAsync(blog);
            await context.SaveChangesAsync();

            return blog;
        }

        /// <summary>
        /// Delete Blog post from DB
        /// Save Async
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async static Task Delete(BlogPost blog, ApplicationDbContext context)
        {
            await context.AddAsync(blog);
            context.Entry(blog).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Edit currently selected Blog Post
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<BlogPost> Edit(BlogPost blog, ApplicationDbContext context)
        {
            await context.AddAsync(blog);
            context.Entry(blog).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return blog;
        }

        /// <summary>
        /// Pull list of all blog items
        /// in DB Context Blog Item
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<List<BlogPost>> GetAllBlogItems(ApplicationDbContext context)
        {
            List<BlogPost> blog = await (from BlogPost in context.BlogPost
                                      select BlogPost).ToListAsync();
            return blog;

        }

        /// <summary>
        /// Pull Blog Post by ID num
        /// by ApDBcontext
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<BlogPost> GetBlogPostById(int id, ApplicationDbContext context)
        {
            BlogPost blog = await (from BlogPost in context.BlogPost
                                   where BlogPost.BlogId == id
                                   select BlogPost).SingleOrDefaultAsync();

            return blog;
        }
    }
}
