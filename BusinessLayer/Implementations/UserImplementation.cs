using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.DBContexts;
using DomainLayer.DTOModels;
using DomainLayer.Entities;

namespace BusinessLayer.Implementations
{
    public class UserImplementation
    {
        internal async Task<ResultsResponse> AddBookAction(BooksData data)
        {
            return await Task.Run(() =>
            {
                if (data.Title == null && data.Author == null)
                    return new ResultsResponse
                    {
                        Result = false,
                        Message = "Complete all fields correct."
                    };
                try
                {
                    using (var db = new StoreContext())
                    {
                        var book = new Books
                        {
                            Title = data.Title,
                            CategoryId = db.Categories.FirstOrDefault(m => m.Name == data.Category),
                            AuthorId = db.Authors.FirstOrDefault(m => m.Name == data.Author),
                            Publisher = data.Publisher,
                            Description = data.Description,
                            Price = data.Price,
                            ImageSrc1 = data.ImageSrc1
                        };
                        db.Books.Add(book);
                        db.SaveChanges();
                    }
                    return new ResultsResponse
                    {
                        Result = true,
                        Message = "Book was added successfully."
                    };
                }
                catch (Exception e)
                {
                    return new ResultsResponse
                    {
                        Result = false,
                        Message = e.Message
                    };
                }

            });
        }

    }
}
