using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutherBook.Domain
{
    public class Book : Super
    {
        [Required]
        [StringLength(32, ErrorMessage = "Tittle Length can't be more than 32 charters")]
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime published { get; set; }
        [ForeignKey("Author.Id")]
        public int AuthorId { get; set; }
    }
}