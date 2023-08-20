/* ************************************************************
 * For students to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * ************************************************************/
using BookStoreDATA;
using System.Data;

namespace BookStoreLIB
{
    public class BookCatalog
    {
        public DataSet GetBookInfo()
        {
            //perform any business logic befor passing to client.
            // None needed at this time.
            DALBookCatalog bookCatalog = new DALBookCatalog();
            return bookCatalog.GetBookInfo();
        }

        public DataSet SearchByCategory(int categoryId)
        {
            DALBookCatalog bookCatalog = new DALBookCatalog();
            return bookCatalog.GetByCategory(categoryId);
        }

        public DataSet SearchBy(string query, string type)
        {
            DALBookCatalog bookCatalog = new DALBookCatalog();
            if (type != "ISBN" && type != "Title" && type != "Author" && type != "Price" && type != "Year")
                type = "Title";

            return bookCatalog.GetBySimilar(query, type);
        }

        public bool AddBook(string isbn, string title, string author, float price, int year, int categoryId)
        {
            DALBookCatalog bookCatalog = new DALBookCatalog();
            return bookCatalog.AddBook(isbn, title, author, price, year, categoryId) == 1;
        }

        public bool RemoveBook(string isbn)
        {
            DALBookCatalog bookCatalog = new DALBookCatalog();
            return bookCatalog.RemoveBook(isbn) == 1;
        }

        public bool AddCategory(string name)
        {
            DALBookCatalog bookCatalog = new DALBookCatalog();
            return bookCatalog.AddCategory(name) == 1;
        }

        public bool RemoveCategory(int id)
        {
            DALBookCatalog bookCatalog = new DALBookCatalog();
            return bookCatalog.RemoveCategory(id) == 1;
        }
    }
}
