using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookApp.BLL.DTO;

namespace MyBookApp.BLL.Interfaces
{
    public interface IMyBooksService
    {
        void UpdateAuthor(AuthorDTO authorDto);

        void AddAuthor(AuthorDTO authorDto);
        void DeleteAuthor(int id);
        void AddBook(BookDTO bookDto);

        AuthorDTO GetAuthor(int? id);
        BookDTO GetBook(int? id);
        GenreDTO GetGenre(int? id);

        IEnumerable<AuthorDTO> GetAuthors();
        IEnumerable<BookDTO> GetBooks();
        IEnumerable<GenreDTO> GetGenres();

        void Dispose();
    }
}
