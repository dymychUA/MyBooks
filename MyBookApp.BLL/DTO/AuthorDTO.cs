using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookApp.BLL.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual List<BookDTO> Books { get; set; }

    }
}
