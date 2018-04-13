using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT2030_Lab04_Mosinski_MusicStore.Models.ViewModel
{
    public class ShoppingCartRemoveViewModel
    {
        public int DeleteId;    // Match up with RecordId
        public decimal CartTotal;   // This is going to be what the controller returns to the view
        public int ItemCount;
        public int CartCount;
        public string Message;
    }
}