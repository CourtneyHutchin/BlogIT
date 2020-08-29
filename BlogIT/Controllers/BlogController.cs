using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogIT.Data;
using BlogIT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogIT.Controllers
{
    public class BlogController : Controller
    {
        /// <summary>
        /// Set the readonly context so it cannot
        /// be externally edited
        /// </summary>
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a populated viewbag for all the Blog Posts
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> BlogPostIndex()
        {
            ViewBag.BlogBag = await BlogDB.GetAllBlogItems(_context);
            return View();
        }

        /// <summary>
        /// Get the View for the Add
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        /// <summary>
        /// Confirm action result for
        /// adding Blog object to DB and direct view
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(BlogPost blog) 
        {
            if (ModelState.IsValid)
            {
                await BlogDB.Add(blog, _context);
                TempData["Message"] = $"{blog.Title} added successfully";
                return RedirectToAction(nameof(BlogPostIndex));
            }

            return View();
        }

        /// <summary>
        /// Get Blog object for delete
        /// Check for null and return
        /// if found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            BlogPost blog = await BlogDB.GetBlogPostById(id, _context);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        /// <summary>
        /// Process Delete with DB
        /// Return if complete with
        /// Tempdata context message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            BlogPost blog = await BlogDB.GetBlogPostById(id, _context);
            await BlogDB.Delete(blog, _context);
            TempData["Message"] = $"{blog.Title} deleted successfully";
            return RedirectToAction(nameof(BlogPostIndex));
        }

        /// <summary>
        /// Get Blog object for edit
        /// by ID value, if null return 404
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                // HTTP 400
                return BadRequest();
            }
            BlogPost blog = await BlogDB.GetBlogPostById(id.Value, _context);

            if (blog == null)
            {
                return NotFound(); // returns a HTTP 404 - Not Found
            }

            return View(blog);
        }

        /// <summary>
        /// Post edit on valid model,
        /// return confirm temp message
        /// converted to alert message
        /// on actual site usage
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BlogPost blog)
        {
            if (ModelState.IsValid)
            {
                await BlogDB.Edit(blog, _context);
                ViewData["Message"] = blog.Title + " updated successfully";
                return View(blog);
            }

            return View(blog);
        }
    }
}
