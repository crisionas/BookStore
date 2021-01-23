using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.DTOModels
{
    public class BooksData
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] ImageSrc1 { get; set; }
    }
}
