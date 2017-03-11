using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookApp.WEB.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Display(Name = "Название книги")]
        public string Name { get; set; }

        public int AuthorId { get; set; }
        //public AuthorViewModel Author { get; set; }

        public int GenreId { get; set; }
        public GenreViewModel Genre { get; set; }

        [Display(Name = "Количество страниц")]
        public int NumberOfPages { get; set; }
    }
}