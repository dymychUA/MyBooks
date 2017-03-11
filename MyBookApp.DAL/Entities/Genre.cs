using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookApp.DAL.Entities
{
    public class Genre
    {
        //ID жанра
        [Key]
        public int GenreId { get; set; }
        //Название жанра
        public string Name { get; set; }
        //Книги
        public List<Book> Books { get; set; }
    }
}
