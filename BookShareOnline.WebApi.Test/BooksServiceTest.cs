using BookShareOnline.Service.Controllers;
using BookShareOnline.WebAPI.Data.Models;
using BookShareOnline.WebAPI.Data.Models.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BookShareOnline.WebApi.Test
{
    [TestClass]
    public class BooksServiceTest
    {
        [TestMethod]
        public void GetBooks()
        {
            List<Book> books = new List<Book>();
            var mock = new Mock<IBookRepository>();
            mock.Setup(p => p.Get()).Returns(books);
            BooksController home = new BooksController(mock.Object,null);
            IEnumerable<Book> result = home.Get();
            Assert.AreEqual(books, result);
        }
    }
}
