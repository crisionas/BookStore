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
    public class UserController : ControllerBase
    {
        private IUser user;

        public UserController()
        {
            var bl = new BusinessManager();
            user = bl.UserBL();
        }

        [HttpPost]
        [ActionName("AddBook")]
        public async Task<ResultsResponse> AddBook(BooksData data)
        {
            return await user.AddBook(data);
        }

    }
}
