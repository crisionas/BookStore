using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Levels;
using DomainLayer.DBContexts;
using DomainLayer.DTOModels;
using DomainLayer.Entities;

namespace BusinessLayer.Implementations
{
    public class BookImplementation
    {
        internal async Task<List<BooksData>> GetBooksAction()
        {

                return await Task.Run(() =>
                {
                    try
                    {
                        using (var db = new StoreContext())
                        {
                            var list = new List<BooksData>();
                            var result = db.Books.Join(db.Categories, t => t.CategoryId, C => C,
                                (t, C) => new {t,C}).ToList();
                            foreach (var item in result)
                            {
                                var book = new BooksData();
                                book.BookId = item.t.BookId;
                                book.Title = item.t.Title;
                                book.Category = item.C.Name;
                                book.Author = item.t.Author;
                                book.Description = item.t.Description;
                                book.ImageSrc1 = item.t.ImageSrc1;
                                book.Price = item.t.Price;
                                book.Publisher = item.t.Publisher;
                                list.Add(book);
                            }
                             return list;
                        }
                    }
                    catch(Exception e)
                    {
                        //Logging method
                        return null;
                    }
                });
        }
    }
}
