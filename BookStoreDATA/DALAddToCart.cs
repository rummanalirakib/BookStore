using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDATA
{
    public class DALAddToCart
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        public DataSet GetAddToCart(int UserID)
        {
            try
            {
                DataSet dataSet = new DataSet("AddToCart");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AddToCart where UserID=@userID", conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@userID", UserID);
                dataAdapter.Fill(dataSet, "AddToCart");
                conn.Close();
                return dataSet;
            }
            catch (Exception ex)
            {
                return new DataSet("AddToCart");
            }
        }

        public DataSet GetOrderDetails(int UserID)
        {
            try
            {
                DataSet dataSet = new DataSet("OrderDetails");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from BookData as BD inner join OrderItem as OI on BD.ISBN = OI.ISBN inner join Orders as OS on OI.OrderID = OS.OrderID where OS.UserID = @userID order by OrderDate desc", conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@userID", UserID);
                dataAdapter.Fill(dataSet, "OrderDetails");
                conn.Close();
                return dataSet;
            }
            catch (Exception ex)
            {
                return new DataSet("OrderDetails");
            }
        }

        public void SaveAddtoCart(int UserID, string ISBN, string Title, int Quantity, float SubTotal)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            int existingItems = checkItemExists(UserID, ISBN);
            try
            {
                if (existingItems == 0)
                {
                    cmd.CommandText = "INSERT INTO AddToCart VALUES(@userID, @isbn, @title, @quantity, @subTotal)";
                    cmd.Parameters.AddWithValue("@userID", UserID);
                    cmd.Parameters.AddWithValue("@isbn", ISBN);
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@quantity", Quantity);
                    cmd.Parameters.AddWithValue("@subTotal", SubTotal);

                }
                else
                {
                    cmd.CommandText = "UPDATE AddToCart SET Quantity = @quantity, SubTotal = @subTotal WHERE UserID = @userID and ISBN = @isbn";
                    cmd.Parameters.AddWithValue("@userID", UserID);
                    cmd.Parameters.AddWithValue("@isbn", ISBN);
                    cmd.Parameters.AddWithValue("@quantity", Quantity + existingItems);
                    cmd.Parameters.AddWithValue("@subTotal", (SubTotal / Quantity) * (Quantity + existingItems));
                }
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex) { }
        }

        public void RemoveFromCart(int UserID, string ISBN)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "DELETE AddToCart WHERE UserID = @userID and ISBN = @isbn";
                cmd.Parameters.AddWithValue("@userID", UserID);
                cmd.Parameters.AddWithValue("@isbn", ISBN);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { }
        }

        public void EmptyBookCart(int UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "DELETE AddToCart WHERE UserID = @userID";
                cmd.Parameters.AddWithValue("@userID", UserID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { }
        }

        private int checkItemExists(int UserID, string ISBN)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from AddToCart where UserID=@userID and ISBN=@isbn";
            cmd.Parameters.AddWithValue("@userID", UserID);
            cmd.Parameters.AddWithValue("@isbn", ISBN);
            int count1 = 0;
            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count1++;
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return count1;
        }
    }
}
