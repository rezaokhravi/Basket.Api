﻿using System.Collections.Generic;

namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; set; }
        public List<ShoppingCartItem> Itmes { get; set; }

        public decimal TotalPrice { 
            get { 
                decimal totalPrice = 0;
                foreach (ShoppingCartItem item in Itmes)
                {
                    totalPrice += item.Price * item.Quntity;
                }

                return totalPrice;
            } 
        }
    }
}
