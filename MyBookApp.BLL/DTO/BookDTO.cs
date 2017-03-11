using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookApp.BLL.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        //public virtual AuthorDTO Author { get; set; }
        public int GenreId { get; set; }
        public virtual GenreDTO Genre { get; set; }
        public int NumberOfPages { get; set; }
    }
}
