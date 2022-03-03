using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Checkout> Checkout => context.Checkout.Include(x => x.Lines).ThenInclude(x => x.Books);

        IQueryable<Checkout> ICheckoutRepository.Checkout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Books));

            if (checkout.CheckoutId == 0 )
            {
                context.Checkout.Add(checkout);
            }
            
            context.SaveChanges();

        }
    }
}
