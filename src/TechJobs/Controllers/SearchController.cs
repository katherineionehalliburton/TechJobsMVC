using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<String, String>> jobs = new List<Dictionary<string, string>>();

            if (column.Equals("all"))
            {
                //ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Results:";
                jobs = JobData.FindByValue(searchTerm);                
                ViewBag.jobs = jobs;
                return View("Search/Index");
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "All Selected Values";
                ViewBag.column = searchType;
                ViewBag.items = jobs;
                return View("Search/Index");
            }
        }
    }
}
