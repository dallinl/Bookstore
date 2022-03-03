using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreContext context { get; set; }
        public HomeController(BookstoreContext bsc)
        {
            context = bsc;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult BookList(int pageNum = 1)
        //{
        //    int pageSize = 10;

        //    var x = new ProjectsViewModel
        //    {
        //        Books = context.Books
        //        .OrderBy(x => x.Title)
        //        .Skip((pageNum - 1) * pageSize)
        //        .Take(pageSize),

        //        PageInfo = new PageInfo
        //        {
        //            TotalNumProjects = context.Books.Count(),
        //            ProjectsPerPage = pageSize,
        //            CurrentPage = pageNum
        //        }
        //    };

        //    return View(x);

        //}

        [HttpGet]
        public IActionResult Index (string categoryType, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new ProjectsViewModel
            {
                Books = context.Books
                .Where(x => x.Category == categoryType || categoryType == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = (categoryType == null
                        ? context.Books.Count()
                        : context.Books.Where(x => x.Category == categoryType).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);

        }

    }
}
