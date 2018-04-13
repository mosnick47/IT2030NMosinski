using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT2030_Lab04_Mosinski_MusicStore.Models
{
    public class ShoppingCart
    {
        private string ShoppingCartId;
        private string CartSessionKey = "CartId";       // This variable will be used to identify which session is which
        // Database Context
        IT2030_Lab07_Mosinski_MusicStoreDB db = new IT2030_Lab07_Mosinski_MusicStoreDB();

        // Method that creates and returns a new shopping cart.
        // All the manipulations to the cart objects will happen through this GetCart Method
        // Every controller method in ShoppingCartController will call this method.
        public static ShoppingCart GetCart(HttpContextBase context)    // In order to access the shopping cart for any reason, the code will enter this method. 'HttpContextBase context' is unique to every session!
        {                                                              // 'HttpContextBase context' will be used to figure out the session variable that will be used to figure out the cartID
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        public string GetCartId(HttpContextBase context)    // Session variables are key/value pairs
        {
            string cartId;
            if(context.Session[CartSessionKey] == null)
            {
                // Create a cart id and add it to thh sesion variable
                cartId = Guid.NewGuid().ToString();  // Creating a new Guid and assigning it to tempId
                context.Session[CartSessionKey] = cartId;   // Storing the tempId/Guid in session
            }
            else
            {
                // retrive cart id
                cartId = context.Session[CartSessionKey].ToString();    // Get CartId from session    
            }

            return cartId;
        }

        // Returns a list of all of the items in the cart
        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartID == ShoppingCartId).ToList();  // this is going to return all of the items that match the Cart's Guid
        }

        // Returns the total amount of all of the items in the cart
        public decimal GetCartTotal()
        {
            decimal? total = (from cartItems in db.Carts where cartItems.CartID == ShoppingCartId select cartItems.AlbumSelected.Price * (int?)cartItems.Count).Sum();            
            return total ?? decimal.Zero;
        }

        public void AddToCart(int id)
        {                        
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartID == ShoppingCartId && c.AlbumId == id);            

            if(cartItem == null)
            {
                Album album = db.Albums.SingleOrDefault(a => a.AlbumId == id);
                //CartItem does not exist in db =? add CartItem to database
                cartItem = new Cart()
                {
                    CartID = ShoppingCartId,
                    AlbumId = id,
                    AlbumSelected = album,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else
            {
                //CartItem exists already in db => Update count
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            Cart cartItem = db.Carts.SingleOrDefault(cart => cart.RecordId == id);
            int count = 0;

            if(cartItem != null)
            {
                // cartItem count == 1; we need to update the database and remove the row from the table
                if(cartItem.Count > 1)
                {
                    cartItem.Count--;
                    count = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                    count = 0;
                }
                db.SaveChanges();
            }
            else
            {

            }

            return count;
        }
    }
}