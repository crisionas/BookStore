using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DomainLayer.DTOModels;

namespace BookStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook book;
        public BookController()
        {
            var bl = new BusinessManager();
            book = bl.BooksBL();
        }
        [HttpGet]
        [ActionName("Books")]
        public async Task<List<BooksData>> GetAllBooks()
        {
            return await book.GetAllBooks();
        }

        [HttpGet]
        [ActionName("Authors")]
        public async Task<List<AuthorsData>> GetAuthors()
        {
            return await book.GetAuthors();
        }


    }
}
