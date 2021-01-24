using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using DomainLayer.DTOModels;

namespace BusinessLayer.Levels
{
    class UserLevel:UserImplementation,IUser
    {
        public async Task<ResultsResponse> AddBook(BooksData data)
        {
            return await AddBookAction(data);
        }

        public async Task<ResultsResponse> BuyBook(BuyBook data)
        {
            return await BuyBookAction(data);
        }
    }
}
