using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookApp.DAL.Entities
{
    public class Author
    {
        //ID автора
        [Key]
        public int AuthorId { get; set; }

        //Фамилия автора
        [Required(ErrorMessage = "Введите фамилию автора.")]
        public string LastName { get; set; }

        //Имя автора
        [Required(ErrorMessage = "Введите имя автора.")]
        public string FirstName { get; set; }

        //Отчество автора
        [Required(ErrorMessage = "Введите отчество автора.")]
        public string MiddleName { get; set; }

        //Дата рождения
        [Required(ErrorMessage = "Введите дату рождения автора.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        //Книги
        public virtual List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}