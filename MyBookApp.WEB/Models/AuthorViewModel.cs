using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookApp.WEB.Models
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию автора.")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя автора.")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Введите отчество автора.")]
        public string MiddleName { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Введите дату рождения автора.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public List<BookViewModel> Books { get; set; }

    }
}