using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DomainLayer.DTOModels;

namespace BusinessLayer.Levels
{
    public class BookLevel : BookImplementation, IBook
    {
        public async Task<List<BooksData>> GetAllBooks()
        {
            return await GetBooksAction();
        }

        public async Task<List<AuthorsData>> GetAuthors()
        {
            return await GetAuthorsAction();
        }
    }
}
