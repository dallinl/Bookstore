using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class CartModel : PageModel
    {
        private BookstoreContext repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel (BookstoreContext temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl } );
        }

        public IActionResult OnPostRemove (int bookid, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Books.BookId == bookid).Books);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
