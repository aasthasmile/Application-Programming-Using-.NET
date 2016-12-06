using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ch24ShoppingCartMVC.Models.DataAccess;

namespace Ch24ShoppingCartMVC.Models
{
    public class Checkoutmodel
    {
        public List<State> GetAllStatesFromDataStore()
        {
            using (HalloweenEntities data = new HalloweenEntities())
            {  //get all the products from the Collection Products order by name using HalloweenEntities
                return data.States.OrderBy(p => p.StateCode).ToList();
            }
        }
        public List<ProductViewModel> GetCartFromDataStore()
        {
            List<ProductViewModel> cart;
            object objCart = HttpContext.Current.Session["cart"];
            //Convert objCart to List<ProductViewModel>
            cart = (List<ProductViewModel>)objCart;
            if (cart == null)
            {   //Create the object cart
               cart = new List<ProductViewModel>();
                //Assign cart to the Session object cart
               HttpContext.Current.Session["cart"] = cart;
               // cart = (List<ProductViewModel>)objCart;
            }
            return cart;
        }

        public CheckoutViewModel GetCart(string id = "")
        {
            CheckoutViewModel model = new CheckoutViewModel();
            //Call the method GetCartFromDataStore
            model.Cart = GetCartFromDataStore();
            if (!string.IsNullOrEmpty(id))
                //Called the method GetSelectedProduct with parameter id and assign the return object to the AddedProduct
                model.AddedProduct = GetSelectedProduct(id);
            return model;
        }

        private ProductViewModel GetSelectedProduct(string id)
        {   //Create an OrderModel object called order
            Checkoutmodel order = new Checkoutmodel();
            //Call the method GetSelectedProduct of the class OrderModel. Return the object returned by the call.
            return order.GetSelectedProduct(id);
        }


    }
}