using System;
using MyBookApp.BLL.DTO;
using MyBookApp.DAL.Entities;
using MyBookApp.DAL.Interfaces;
using MyBookApp.BLL.Infrastructure;
using MyBookApp.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using MyBookApp.BLL.Util;

namespace MyBookApp.BLL.Services
{
    public class MyBooksService : IMyBooksService
    {
        IUnitOfWork Database { get; set; }
        IMapper bookMapper = BookMapperDefaultProfile.Mapper;

        public MyBooksService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void UpdateAuthor(AuthorDTO authorDTO)
        {
            Author author = bookMapper.Map<AuthorDTO, Author>(authorDTO);
            Database.Authors.Update(author);
        }

        public void AddAuthor(AuthorDTO authorDTO)
        {
            Author author = bookMapper.Map<AuthorDTO, Author>(authorDTO);
            Database.Authors.Create(author);
            Database.Save();
        }

        public void DeleteAuthor(int id)
        {
            Database.Authors.Delete(id);
        }

        public void AddBook(BookDTO bookDTO)
        {
            Book book = bookMapper.Map<BookDTO, Book>(bookDTO);
            Database.Books.Create(book);
            Database.Save();
        }

        public AuthorDTO GetAuthor(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id автора", "");
            var author = Database.Authors.Get(id.Value);

            if (author == null)
                throw new ValidationException("Автор не найден", "");

            return bookMapper.Map<Author, AuthorDTO>(author);
        }

        public BookDTO GetBook(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги", "");
            var book = Database.Books.Get(id.Value);

            if (book == null)
                throw new ValidationException("Книга не найдена", "");

            return bookMapper.Map<Book, BookDTO>(book);
        }

        public GenreDTO GetGenre(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id жанра", "");
            var genre = Database.Genres.Get(id.Value);

            if (genre == null)
                throw new ValidationException("Жанр не найден", "");

            return bookMapper.Map<Genre, GenreDTO>(genre);
        }

        public IEnumerable<AuthorDTO> GetAuthors()
        {
            return bookMapper.Map<IEnumerable<Author>, List<AuthorDTO>>(Database.Authors.GetAll());
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            return bookMapper.Map<IEnumerable<Book>, List<BookDTO>>(Database.Books.GetAll());
        }

        public IEnumerable<GenreDTO> GetGenres()
        {
            return bookMapper.Map<IEnumerable<Genre>, List<GenreDTO>>(Database.Genres.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
