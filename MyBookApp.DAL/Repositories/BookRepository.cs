using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookApp.DAL.Entities;
using MyBookApp.DAL.EF;
using MyBookApp.DAL.Interfaces;
using System.Data.Entity;

namespace MyBookApp.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private BookContext db;

        public BookRepository(BookContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.Include(b=>b.Genre);
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Book> Find(Func<Book, Boolean> predicate)
        {
            return db.Books.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}
