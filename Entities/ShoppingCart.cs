using System.Collections.Generic;
using System.Linq;

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
                if (Itmes != null && Itmes.Any())
                {
                    foreach (ShoppingCartItem item in Itmes)
                    {
                        totalPrice += item.Price * item.Quntity;
                    }
                }
                return totalPrice;
            } 
        }
    }
}
