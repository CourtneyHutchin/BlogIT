using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogIT.Models;

namespace BlogIT.Controllers
{
    public class AboutMeController : Controller
    {
        [HttpGet]
        public IActionResult AboutMePage()
        {
            return View();
        }
    }
}
