using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT2030_Lab04_Mosinski_MusicStore.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems;    // Creates our list of Cart items
        public decimal CartTotal;       // Aggregate sum of the total cost of all items in the cart
    }
}