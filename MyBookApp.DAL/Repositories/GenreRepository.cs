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
    public class GenreRepository : IRepository<Genre>
    {
        private BookContext db;

        public GenreRepository(BookContext context)
        {
            this.db = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }

        public void Create(Genre genre)
        {
            db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
        }

        public IEnumerable<Genre> Find(Func<Genre, Boolean> predicate)
        {
            return db.Genres.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }
    }
}
