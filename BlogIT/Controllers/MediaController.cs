using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogIT.Models;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

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
            var newsApiClient = new NewsApiClient("5a6f078ea39446cda5b9698ccd4e26be");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Apple",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2020, 7, 21)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                return View(articlesResponse.Articles);

                // Code below was changed to return the view above as a bag model, this was API standard
                /* 
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Console.WriteLine(article.Title);
                    // author
                    Console.WriteLine(article.Author);
                    // description
                    Console.WriteLine(article.Description);
                    // url
                    Console.WriteLine(article.Url);
                    // published at
                    Console.WriteLine(article.PublishedAt);
                }*/
            }
            //Console.ReadLine();


            return View();
        }
    }
}
