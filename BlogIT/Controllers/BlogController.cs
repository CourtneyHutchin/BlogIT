using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogIT.Data;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
