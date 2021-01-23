using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DTOModels;

namespace BusinessLayer.Interfaces
{
    public interface IBook
    {
        Task<List<BooksData>> GetAllBooks();
    }
}
