using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookApp.DAL.EF;
using MyBookApp.DAL.Interfaces;
using MyBookApp.DAL.Entities;

namespace MyBookApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BookContext db;
        private AuthorRepository authorRepository;
        private BookRepository bookRepository;
        private GenreRepository genreRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new BookContext(connectionString);
        }
        public IRepository<Author> Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new AuthorRepository(db);
                return authorRepository;
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
