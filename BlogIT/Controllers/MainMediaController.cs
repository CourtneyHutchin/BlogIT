using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogIT.Controllers
{
    public class MainMediaController : Controller
    {
        public IActionResult MainMediaPage()
        {
            return View();
        }
    }
}
