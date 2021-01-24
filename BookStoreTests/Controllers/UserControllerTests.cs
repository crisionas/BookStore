using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DomainLayer.DTOModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        private UserController _controller;

        public UserControllerTests()
        {
            _controller = new UserController();
        }
        [TestMethod()]
        public async Task AddBookTest()
        {
            var book = new BooksData
            {
                Title = "Designed for Digital",
                Category = "Tech",
                Author = "Jeanne W. Ross",
                Publisher = "X",
                Price = 100
            };
            var result =await  _controller.AddBook(book);
            Assert.IsTrue(result.Result);
        }


    }
}