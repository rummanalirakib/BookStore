using BookStoreDATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLIB
{
    public class CartAndOrder
    {
        DALCartInfo dALCartInfo = new DALCartInfo();
        public bool GetBookSearchResult(int userID, string bookSearch)
        {
            bool ret = dALCartInfo.GetBookSearchPriceQuantityResult(userID, bookSearch, 0, 0, "book");
            return ret;
        }

        public bool GetBookPrice(int userID, float bookPrice)
        {
            bool ret = dALCartInfo.GetBookSearchPriceQuantityResult(userID, "", bookPrice, 0, "price");
            return ret;
        }

        public bool GetUpdatedBookQuantity(int userID, int bookQuantity)
        {
            bool ret = dALCartInfo.GetBookSearchPriceQuantityResult(userID, "", 0, bookQuantity, "quantity");
            return ret;
        }

        public bool CheckAddToCart(int userID)
        {
            bool ret = dALCartInfo.CheckAddToCart(userID);
            return ret;
        }

        public int GetAddToCartItem(int userID, int expectedReturn)
        {
            int ret = dALCartInfo.GetAddToCartItem(userID);
            return ret;
        }

        public bool GetOrderCheck(int userID)
        {
            bool ret = dALCartInfo.GetOrderCheck(userID);
            return ret;
        }

        public int GetTotalItemsNumber(int userID)
        {
            int ret = dALCartInfo.GetTotalItemsNumber(userID);
            return ret;
        }

        public int GetTotalOrderDetails(int userID)
        {
            int ret = dALCartInfo.GetTotalOrderDetails(userID);
            return ret;
        }
    }
}
