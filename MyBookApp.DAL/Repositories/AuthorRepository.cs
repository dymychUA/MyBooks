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
    public class AuthorRepository : IRepository<Author>
    {
        private BookContext db;

        public AuthorRepository(BookContext context)
        {
            this.db = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors.Include(a => a.Books).OrderBy(a => (a.LastName + " " + a.FirstName + " " + a.MiddleName)).ToList();
            //return db.Authors.OrderBy(a => (a.LastName + " " + a.FirstName + " " + a.MiddleName));
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Author> Find(Func<Author, Boolean> predicate)
        {
            return db.Authors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author != null)
            {
                db.Authors.Remove(author);
                db.SaveChanges();
            }
        }
    }
}
