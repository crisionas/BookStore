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
        public Task<List<BooksData>> GetAllBooks()
        {
            return GetBooksAction();
        }
    }
}
