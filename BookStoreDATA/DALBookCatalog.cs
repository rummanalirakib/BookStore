﻿/* ************************************************************
 * For students to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * ************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BookStoreDATA
{
    public class DALBookCatalog
    {
        SqlConnection conn;
        DataSet dsBooks;
        public DALBookCatalog()
        {
            conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        }
        public int AddCategory(string name)
        {
            try
            {
                conn.Open();
                String strSQL = "INSERT INTO Category (Name) VALUES(@Name)";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("Name", name);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        public int RemoveCategory(int id)
        {
            try
            {
                conn.Open();
                String strSQL = "DELETE FROM Category WHERE CategoryID = @ID";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("ID", id);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        public int AddBook(string isbn, string title, string author, float price, int year, int categoyId)
        {
            try
            {
                conn.Open();
                String strSQL = "INSERT INTO BookData (ISBN, Title, Author, Price, Year, CategoryID) VALUES(@ISBN, @Title, @Author, @Price, @Year, @CategoryID)";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("ISBN", isbn);
                cmd.Parameters.AddWithValue("Title", title);
                cmd.Parameters.AddWithValue("Author", author);
                cmd.Parameters.AddWithValue("Price", price);
                cmd.Parameters.AddWithValue("Year", year);
                cmd.Parameters.AddWithValue("CategoryID", categoyId);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        public int RemoveBook(string isbn)
        {
            try
            {
                conn.Open();
                String strSQL = "DELETE FROM BookData WHERE ISBN = @ISBN";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("ISBN", isbn);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        public DataSet GetBookInfo()
        {
            try
            {
                String strSQL = "Select CategoryID, Name, Description from Category";
                SqlCommand cmdSelCategory = new SqlCommand(strSQL, conn);
                SqlDataAdapter daCatagory = new SqlDataAdapter(cmdSelCategory);
                dsBooks = new DataSet("Books");
                daCatagory.Fill(dsBooks, "Category");            //Get category info
                String strSQL2 = "Select ISBN, CategoryID, Title," +
                    "Author, Price, Year, Edition, Publisher from BookData";
                SqlCommand cmdSelBook = new SqlCommand(strSQL2, conn);
                SqlDataAdapter daBook = new SqlDataAdapter(cmdSelBook);
                daBook.Fill(dsBooks, "Books");                  //Get Books info
                DataRelation drCat_Book = new DataRelation("drCat_Book",
                dsBooks.Tables["Category"].Columns["CategoryID"],
                dsBooks.Tables["Books"].Columns["CategoryID"], false);
                dsBooks.Relations.Add(drCat_Book);       //Set up the table relation
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return dsBooks;
        }

        public DataSet GetByCategory(int categoryId)
        {
            try
            {
                String strSQL = "Select CategoryID, Name, Description from Category";
                SqlCommand cmdSelCategory = new SqlCommand(strSQL, conn);
                SqlDataAdapter daCatagory = new SqlDataAdapter(cmdSelCategory);
                dsBooks = new DataSet("Books");
                daCatagory.Fill(dsBooks, "Category");            //Get category info
                String strSQL2 = "Select ISBN, CategoryID, Title," +
                    "Author, Price, Year, Edition, Publisher from BookData WHERE CategoryID = @CategoryID";
                SqlCommand cmdSelBook = new SqlCommand(strSQL2, conn);
                cmdSelBook.Parameters.AddWithValue("CategoryID", categoryId);
                SqlDataAdapter daBook = new SqlDataAdapter(cmdSelBook);
                daBook.Fill(dsBooks, "Books");                  //Get Books info
                DataRelation drCat_Book = new DataRelation("drCat_Book",
                dsBooks.Tables["Category"].Columns["CategoryID"],
                dsBooks.Tables["Books"].Columns["CategoryID"], false);
                dsBooks.Relations.Add(drCat_Book);       //Set up the table relation
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return dsBooks;
        }

        public DataSet GetBySimilar(String query, string field)
        {
            try
            {
                String strSQL = "Select CategoryID, Name, Description from Category";
                SqlCommand cmdSelCategory = new SqlCommand(strSQL, conn);
                SqlDataAdapter daCatagory = new SqlDataAdapter(cmdSelCategory);
                dsBooks = new DataSet("Books");
                daCatagory.Fill(dsBooks, "Category");            //Get category info
                String strSQL2 = "Select ISBN, CategoryID, Title," +
                    "Author, Price, Year, Edition, Publisher from BookData WHERE " + field + " LIKE @Query";
                SqlCommand cmdSelBook = new SqlCommand(strSQL2, conn);
                cmdSelBook.Parameters.AddWithValue("Query", '%' + query + '%');
                SqlDataAdapter daBook = new SqlDataAdapter(cmdSelBook);
                daBook.Fill(dsBooks, "Books");                  //Get Books info
                DataRelation drCat_Book = new DataRelation("drCat_Book",
                dsBooks.Tables["Category"].Columns["CategoryID"],
                dsBooks.Tables["Books"].Columns["CategoryID"], false);
                dsBooks.Relations.Add(drCat_Book);       //Set up the table relation
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return dsBooks;
        }
    }
}
