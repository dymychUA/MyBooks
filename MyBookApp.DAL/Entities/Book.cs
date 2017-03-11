using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBookApp.DAL.Entities
{
    public class Book
    {
        //ID книги
        [Key]
        public int BookId { get; set; }

        public string Name { get; set; }

        //ID автора
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        //ID жанра
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        public int NumberOfPages { get; set; }
    }
}
