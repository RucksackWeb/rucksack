using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.ViewModels
{
    public class CheckoutViewModel
    {

        public Order Order { get; set; }
        public ApplicationUser User { get; set; }

        [Display(Name = "Street Address")]
        public string BillingStreet { get; set; }

        [Display(Name = "City")]
        public string BillingCity { get; set; }

        [Display(Name = "State")]
        public string BillingState { get; set; }

        [Display(Name = "Zip Code")]
        public string BillingZipcode { get; set; }
        

        [Display(Name = "Credit Card Number")]
        public CreditCard CC { get; set; }

        [Display(Name = "Experation Date")]
        public string ExpireDate { get; set; }
    }
    

    public enum CreditCard : long
    {
        [Display(Name ="Amerian Express")]
        American = 370000000000002,

        [Display(Name = "Discover")]
        Discover = 6011000000000012,

        [Display(Name = "JCB")]
        JCB = 3088000000000017,

        [Display(Name = "Diners Club / Carte Blanche")]
        DinersClub = 38000000000006,

        [Display(Name ="Visa")]
        Visa = 4007000000027,

        [Display(Name ="Mastercard")]
        Mastercard = 5424000000000015
    };
}
