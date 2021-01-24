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
                                (t, C) => new {t,C})
                                .Join(db.Authors, a=>a.t.AuthorId, c2=>c2,(a,c2)=>new{a,c2})
                                .ToList();
                            foreach (var item in result)
                            {
                                var book = new BooksData
                                {
                                    BookId = item.a.t.BookId,
                                    Title = item.a.t.Title,
                                    Category = item.a.C.Name,
                                    Author = item.c2.Name,
                                    Description = item.a.t.Description,
                                    ImageSrc1 = item.a.t.ImageSrc1,
                                    Price = item.a.t.Price,
                                    Publisher = item.a.t.Publisher
                                };
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
