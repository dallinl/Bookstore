using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Checkout
    { 
        [Key]
        [BindNever]  // Stops it from showing up in URL or having user access through url 
        public int CheckoutId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }


        // Make sure that user knows what field is generating the error 
        [Required(ErrorMessage ="Please enter your name.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter your address.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        
        [Required(ErrorMessage = "Please enter your city.")]
        public string City { get; set; }

        
        [Required(ErrorMessage = "Please enter your state.")]
        public string State { get; set; }

        
        [Required(ErrorMessage = "Please enter your zip code.")]
        public string Zip { get; set; }


        [Required(ErrorMessage = "Please enter your country.")]
        public string Country { get; set; }

        public bool Anonymous { get; set; }

        [BindNever]
        public bool Shipped { get; set; } = false;

    }
}
