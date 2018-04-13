using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT2030_Lab04_Mosinski_MusicStore.Models.ViewModel;
using IT2030_Lab04_Mosinski_MusicStore.Models;

namespace IT2030_Lab04_Mosinski_MusicStore.Controllers
{
    // This controller will access the business layer and will not access the data directly
    public class ShoppingCartController : Controller
    {
        IT2030_Lab07_Mosinski_MusicStoreDB dbcontext = new IT2030_Lab07_Mosinski_MusicStoreDB();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext); // Creates a cart variable and calls the ShopingCart class's 'GetCart()' method to
            ShoppingCartViewModel vm = new ShoppingCartViewModel()     // actually create the cart object. Passes the HttpContext object to store the session.
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetCartTotal()
            };
            return View(vm);                                              
        }

        // GET: /ShoppingCart/AddToCart/#
        public ActionResult AddToCart(int id)
        {
            // id is AlbumId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(id);
            return RedirectToAction("Index");
        }

        // POST: AjaxCall--------/ShoppingCart/RemoveFromCart/#
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // id == RecordId
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            string albumTitle = dbcontext.Carts.SingleOrDefault(c => c.RecordId == id).AlbumSelected.Title;
            int itemCnt = cart.RemoveFromCart(id);

            ShoppingCartRemoveViewModel vm = new ShoppingCartRemoveViewModel()
            {
                ItemCount = itemCnt,
                DeleteId = id,
                CartTotal = cart.GetCartTotal(),
                CartCount = 0,
                Message = albumTitle + " has been removed from the cart"
            };

            return Json(vm);
        }
    }
}