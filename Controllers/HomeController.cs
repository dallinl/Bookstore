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

        //public void SaveBook(Books book)
        //{
        //    context.SaveChanges();
        //}

        //public void CreateBook(Books book)
        //{
        //    context.Add(book);
        //    context.SaveChanges();
        //}

        //public void DeleteBook(Books book)
        //{
        //    context.Remove(book);
        //    context.SaveChanges();
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
