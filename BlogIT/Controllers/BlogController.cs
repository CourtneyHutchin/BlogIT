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
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> BlogPostIndex()
        {
            ViewBag.BlogBag = await BlogDB.GetAllBlogItems(_context);
            return View();
        }


        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BlogPost blog) 
        {
            if (ModelState.IsValid)
            {
                await BlogDB.Add(blog, _context);
                TempData["Message"] = $"{blog.Title} added successfully";
                return RedirectToAction(nameof(BlogPost));
            }

            return View();
        }

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

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            BlogPost blog = await BlogDB.GetBlogPostById(id, _context);
            await BlogDB.Delete(blog, _context);
            TempData["Message"] = $"{blog.Title} deleted successfully";
            return RedirectToAction(nameof(BlogPostIndex));
        }

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
