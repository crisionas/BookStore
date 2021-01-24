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
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public Categories CategoryId { get; set; }

        [Required]
        public Authors AuthorId { get; set; }

        [Required]
        [StringLength(80)]
        public string Publisher { get; set; }

        [StringLength(3000)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        
        public byte[] ImageSrc1 { get; set; }
    }
}
