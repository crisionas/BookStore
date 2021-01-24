using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers.Tests
{
    [TestClass()]
    public class BookControllerTests
    {
        private BookController _controller;

        public BookControllerTests()
        {
            _controller = new BookController();
        }

        [TestMethod()]
        public async Task GetAllBooksTest()
        {
            var response = await _controller.GetAllBooks();
            Assert.IsNotNull(response);
        }
    }
}