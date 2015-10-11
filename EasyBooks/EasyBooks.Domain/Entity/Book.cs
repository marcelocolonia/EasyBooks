using System;
using System.ComponentModel.DataAnnotations;

namespace EasyBooks.Domain
{
    public class Book : BaseEntity
    {
        [Required()]
        [StringLength(20, ErrorMessage = "Author is invalid")]
        public string Author { get; set; }

        [Required()]
        [StringLength(50, ErrorMessage = "Title is invalid")]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        [Required()]
        [DataType(DataType.Currency, ErrorMessage = "Price is invalid")]
        public decimal Price { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime PublicationDate { get; set; }

        [Required()]
        [StringLength(200, ErrorMessage = "Description is invalid")]
        public string Description { get; set; }
    }

    public enum Genre
    {
        ACTION,
        ADVENTURE,
        COMEDY,
        DRAMA,
        ROMANCE,
        TERROR
    }
}
