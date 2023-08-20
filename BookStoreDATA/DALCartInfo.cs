using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDATA
{
    public class DALCartInfo
    {
        public bool GetBookSearchPriceQuantityResult(int userID, string search, float price, int quantity, string filter)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (filter == "book")
                {
                    cmd.CommandText = "Select UserID from AddToCart where "
                        + " UserID = @userID and Title = @title ";
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@title", search);
                }
                else if(filter == "price")
                {
                    cmd.CommandText = "Select UserID from AddToCart where "
                    + " UserID = @userID and SubTotal = @subTotal ";
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@subTotal", price);
                }
                else if(filter == "quantity")
                {
                    cmd.CommandText = "Select UserID from AddToCart where "
                   + " UserID = @userID and Quantity = @bookQuantity ";
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@bookQuantity", quantity);
                }
                conn.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool CheckAddToCart(int userID)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * from AddToCart where "
                + " UserID = @userID ";
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int GetAddToCartItem(int userID)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select COUNT(*) from AddToCart where "
                + " UserID = @userID ";
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    return 0;
                }
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool GetOrderCheck(int userID)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select COUNT(*) from Orders where "
                + " UserID = @userID ";
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int GetTotalItemsNumber(int userID)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select SUM(Quantity) from AddToCart where "
                + " UserID = @userID ";
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    return 0;
                }
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int GetTotalOrderDetails(int userID)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select COUNT(*) from BookData as BD inner join OrderItem as OI on BD.ISBN = OI.ISBN inner join Orders as OS on OI.OrderID = OS.OrderID where OS.UserID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    return 0;
                }
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
