using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace BookStoreLIB
{
    /// <summary>
    /// Summary description for PlaceAnOrderTesting
    /// </summary>
    [TestClass]
    public class BookSearcTests
    {
        BookCatalog booksCatalog = new BookCatalog();

        [TestMethod]
        public void TestIfAnyBookIsReturned()
        {
            DataSet books = booksCatalog.GetBookInfo();
            int rowsCount = books.Tables[1].Rows.Count;
            Assert.IsTrue(rowsCount > 0);
        }

        [TestMethod]
        public void TestIfTitleIsCorrect()
        {
            DataSet books = booksCatalog.GetBookInfo();
            var firstRow = books.Tables[1].Rows[0];
            Assert.AreEqual(firstRow["Title"], "Book 1");
        }

        [TestMethod]
        public void TestIfISBNIsCorrect()
        {
            DataSet books = booksCatalog.GetBookInfo();
            var firstRow = books.Tables[1].Rows[3];
            Assert.AreEqual(firstRow["ISBN"], "978-1-60309-503-7");
        }

        [TestMethod]
        public void TestSearchByTitle()
        {
            DataSet books = booksCatalog.SearchBy("Book 1", "Title");
            var firstRow = books.Tables[1].Rows[0];
            Assert.AreEqual(firstRow["Title"], "Book 1");
        }

        [TestMethod]
        public void TestIfSearchForNonExistentValue()
        {
            DataSet books = booksCatalog.SearchBy("Value doesn't exist", "Title");
            Assert.AreEqual(books.Tables[1].Rows.Count, 0);
        }

        [TestMethod]
        public void TestIfSearchForNonExistentValueWorks()
        {
            DataSet books = booksCatalog.SearchBy("Value doesn't exist", "Title");
            Assert.AreEqual(books.Tables[1].Rows.Count, 0);
        }

        [TestMethod]
        public void TestSearchByCategoryID()
        {
            DataSet books = booksCatalog.SearchByCategory(2);
            Assert.IsTrue(books.Tables[1].Rows.Count == 2);
        }

        [TestMethod]
        public void TestIfCategoriesAreFetched()
        {
            DataSet books = booksCatalog.GetBookInfo();
            Assert.IsTrue(books.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        public void TestIfCategoryNameIsLoaded()
        {
            DataSet books = booksCatalog.SearchBy("2014", "Year");
            var firstRow = books.Tables[0].Rows[0];
            Assert.AreEqual(firstRow["Name"], "All Ages");
        }
    }
}
