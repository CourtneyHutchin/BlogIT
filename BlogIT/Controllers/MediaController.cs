using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogIT.Models;

namespace BlogIT.Controllers
{
    public class MediaController : Controller
    {
        /// <summary>
        /// Returns the view of MainMediaPage
        /// Must use MainMediaPage as "Function" Name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MainMediaPage()
        {
            return View();
        }
    }
}
