/* ************************************************************
 * For students to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BookStoreDATA;
using System.Net;
using System.Data;

namespace BookStoreLIB
{
    public class BookOrder
    {
        ObservableCollection<OrderItem> orderItemList = new
            ObservableCollection<OrderItem>();
        ObservableCollection<OrderItem> orderDetailsItemList = new
            ObservableCollection<OrderItem>();
        DALAddToCart dALAddToCart = new DALAddToCart();

        public ObservableCollection<OrderItem> OrderItemList { 
            get { return orderItemList; }
        }

        public ObservableCollection<OrderItem> GetAddtoCart(int UserID)
        {
            DataSet dataSet = dALAddToCart.GetAddToCart(UserID);
            orderItemList = new ObservableCollection<OrderItem>();
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                int quantity = int.Parse(dr["Quantity"].ToString());
                float subTotal = 0;
                float.TryParse(dr["SubTotal"].ToString(), out subTotal);
                float unitPrice = subTotal / quantity;
                orderItemList.Add(new OrderItem(dr["ISBN"].ToString(), dr["Title"].ToString(), unitPrice, quantity));
            }
            return orderItemList;
        }

        public ObservableCollection<OrderItem> GetOrderDetails(int UserID)
        {
            DataSet dataSet = dALAddToCart.GetOrderDetails(UserID);
            orderDetailsItemList = new ObservableCollection<OrderItem>();
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                int quantity = int.Parse(dr["Quantity"].ToString());
                float subTotal = quantity * float.Parse(dr["Price"].ToString());
                float unitPrice = subTotal / quantity;
                DateTime date = (DateTime)dr["OrderDate"];
                orderDetailsItemList.Add(new OrderItem(dr["ISBN"].ToString(), dr["Title"].ToString(), unitPrice, quantity, date));
            }
            return orderDetailsItemList;
        }

        public void SaveAddToCart(int UserID)
        {
            foreach (var item in orderItemList)
            {
                dALAddToCart.SaveAddtoCart(UserID, item.BookID, item.BookTitle, item.Quantity, item.SubTotal);
            }
        }

        public void AddItem(OrderItem orderItem, int userID)
        {
            bool existingBook = true;
            foreach (var item in orderItemList)
            {
                if (item.BookID == orderItem.BookID)
                {
                    existingBook = false;
                    item.Quantity += orderItem.Quantity;
                    orderItemList.Remove(item);
                    break;
                }
            }
            orderItemList.Add(orderItem);
            if (userID > 0)
            {
                dALAddToCart.SaveAddtoCart(userID, orderItem.BookID, orderItem.BookTitle, orderItem.Quantity, orderItem.SubTotal);
            }
        }

        public void RemoveItem(string productID, int userID)
        {
            foreach (var item in orderItemList)
            {
                if (item.BookID == productID)
                {
                    orderItemList.Remove(item);
                    break;
                }
            }
            if(userID > 0)
            {
                dALAddToCart.RemoveFromCart(userID, productID);
            }
        }
        public double GetOrderTotal()
        {
            if (orderItemList.Count == 0)
            {
                return 0.00;
            }
            else
            {
                double total = 0;
                foreach (var item in orderItemList)
                {
                    total += item.SubTotal;
                }
                return total;
            }
        }

        public int PlaceOrder(int userID)
        {
            string xmlOrder;
            xmlOrder = "<Order UserID='" + userID.ToString() + "'>";
            foreach (var item in orderItemList)
            {
                xmlOrder += item.ToString();
            }
            xmlOrder += "</Order>";
            DALOrder dbOrder = new DALOrder();
            return dbOrder.Proceed2Order(xmlOrder);
        }

        public int ItemNumbers()
        {
            int itemCount = 0;
            foreach (var item in orderItemList)
            {
                itemCount += item.Quantity;
            }
            return itemCount;
        }

        public void EmptyOrderList()
        {
            orderItemList.Clear();
        }
    }
}
