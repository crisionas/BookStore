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
        /// <summary>
        /// Get all books implementation
        /// </summary>
        /// <returns></returns>
        internal async Task<List<BooksData>> GetBooksAction()
        {

                return await Task.Run(() =>
                {
                    try
                    {
                        using (var db = new StoreContext())
                        {
                            var list = new List<BooksData>();
                            var result = db.Books.Join(db.Categories, t => t.CategoryId, c => c.CategoryId, (t, c) => new {t,c})
                                .Join(db.Authors,d=>d.t.CategoryId,c=>c.AuthorId,(d,c)=>new{d,c}).ToList();


                            foreach (var item in result)
                            {
                                var book = new BooksData
                                {
                                    BookId = item.d.t.BookId,
                                    Title = item.d.t.Title,
                                    Category = item.d.c.Name,
                                    Author = item.c.Name,
                                    Description = item.d.t.Description,
                                    ImageSrc1 = item.d.t.ImageSrc1,
                                    Price = item.d.t.Price,
                                    Publisher = item.d.t.Publisher
                                };
                                list.Add(book);
                            }
                            return list;
                        }
                    }
                    catch
                    {
                        //Logging method
                        return null;
                    }
                });
        }

        /// <summary>
        /// Get all authors implementation
        /// </summary>
        /// <returns></returns>
        internal async Task<List<AuthorsData>> GetAuthorsAction()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (var db=new StoreContext())
                    {
                        var query = db.Authors.ToList();
                        var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<Authors, AuthorsData>());
                        var mapper = new Mapper(config);
                       return mapper.Map<List<Authors>,List<AuthorsData>>(query);
                    }
                }
                catch
                {
                    //Logging implementation
                    return null;
                }
            });
        }
    }
}
