using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models
{
    public class CheckoutViewModel
    {
        public List<ProductViewModel> Cart { set; get; }
        public ProductViewModel AddedProduct { get; set; }

        public double tax = 0.09;
        public List<string> PaymentOptions
        {
            get
            {
                List<string> payment = new List<string>();
                payment.Add("Visa");
                payment.Add("MasterCard");
                payment.Add("PayPal");
                return payment;
            }
        }
            public double Total
            {
            get
            {
                double sum = 0;
                foreach (var item in Cart)
                {
                    sum = sum+ (double)(item.UnitPrice) * (item.Quantity);
                }
                return Math.Round(sum, 2);
            }
            }
                public string Addresss { get; set; }
                public string City { get; set; }
                public string State { get; set; }
                public string Country { get; set; }
                
                public int zipcode { get; set; }

    }
}