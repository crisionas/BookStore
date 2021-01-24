using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLayer.Entities
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(80)]
        public string Publisher { get; set; }

        [StringLength(3000)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        
        public byte[] ImageSrc1 { get; set; }

        public Categories Category { get; set; }
        
        public Authors Author { get; set; }

        public ICollection<Purchases> Purchases { get; set; }
    }
}
