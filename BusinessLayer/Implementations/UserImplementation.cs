using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        /// <summary>
        /// Add book implementation
        /// </summary>
        /// <param name="data">Model BooksData that is receiving</param>
        /// <returns></returns>
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
                        var category = db.Categories.FirstOrDefault(m => m.Name == data.Category);
                        var author = db.Authors.FirstOrDefault(m => m.Name == data.Author);
                        var bookFind = db.Books.Where(m => m.Title == data.Title && m.AuthorId == author.AuthorId).FirstOrDefault();
                        if (bookFind==null)
                        {
                            var book = new Books
                            {
                                Title = data.Title,
                                CategoryId = category.CategoryId,
                                AuthorId = author.AuthorId,
                                Publisher = data.Publisher,
                                Description = data.Description,
                                Price = data.Price,
                                ImageSrc1 = data.ImageSrc1
                            };
                            db.Books.Add(book);
                            db.SaveChanges();
                            return new ResultsResponse
                            {
                                Result = true,
                                Message = "The book was added successfully."
                            };
                        }
                        else
                            return new ResultsResponse
                            {
                                Result = false,
                                Message = "The book already exists."
                            };
                    }
                    
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

        /// <summary>
        /// Buy Book implementation
        /// </summary>
        /// <param name="data">Model BuyBok that is receiving</param>
        /// <returns></returns>
        internal async Task<ResultsResponse> BuyBookAction(BuyBook data)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (var db=new StoreContext())
                    {
                        var book = db.Books.FirstOrDefault(m => m.BookId == Int32.Parse(data.BookId));
                        var user = db.Users.FirstOrDefault(m => m.Name == data.Username);
                        if (book.Price <= user.Amount)
                        {
                            var purchase = new Purchases
                            {
                                UserId = user.UserId,
                                BookId = book.BookId,
                                Price = book.Price
                                
                            };
                            db.Purchases.Add(purchase);

                            var account = db.Users.Where(U => U.Name == data.Username).FirstOrDefault();
                            account.Amount = account.Amount - book.Price;
                            db.SaveChanges();

                            return new ResultsResponse
                            {
                                Result = true,
                                Message = "The book was bought successfully."
                            };
                        }
                        else
                        {
                            return new ResultsResponse
                            {
                                Result = false,
                                Message = "There is not enough money in your account. Please refill your account."
                            };
                        }
                    } 
                }
                catch (Exception e)
                {
                    //Logging Implementation
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
