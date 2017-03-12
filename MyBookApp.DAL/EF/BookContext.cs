using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyBookApp.DAL.Entities;
using System.Globalization;

namespace MyBookApp.DAL.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        static BookContext()
        {
            Database.SetInitializer<BookContext>(new MyBookAppDbInitializer());
        }
        public BookContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class MyBookAppDbInitializer : CreateDatabaseIfNotExists<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Authors.Add(new Author { AuthorId = 1, LastName = "Чехов",      FirstName = "Антон",     MiddleName = "Павлович",    BirthDate = DateTime.ParseExact("29-01-1860", "dd-MM-yyyy", CultureInfo.InvariantCulture) });
            db.Authors.Add(new Author { AuthorId = 2, LastName = "Шевченко",   FirstName = "Тарас",     MiddleName = "Григорьевич", BirthDate = DateTime.ParseExact("09-03-1814", "dd-MM-yyyy", CultureInfo.InvariantCulture) });
            db.Authors.Add(new Author { AuthorId = 3, LastName = "Пушкин",     FirstName = "Александр", MiddleName = "Сергеевич",   BirthDate = DateTime.ParseExact("06-06-1799", "dd-MM-yyyy", CultureInfo.InvariantCulture) });
            db.Authors.Add(new Author { AuthorId = 4, LastName = "Гоголь",     FirstName = "Николай",   MiddleName = "Васильевич",  BirthDate = DateTime.ParseExact("01-04-1809", "dd-MM-yyyy", CultureInfo.InvariantCulture) });
            db.Authors.Add(new Author { AuthorId = 5, LastName = "Лукьяненко", FirstName = "Сергей",    MiddleName = "Васильевич",  BirthDate = DateTime.ParseExact("11-04-1968", "dd-MM-yyyy", CultureInfo.InvariantCulture) });
            db.Authors.Add(new Author { AuthorId = 6, LastName = "Шевченко",   FirstName = "Андрей",    MiddleName = "Николаевич ", BirthDate = DateTime.ParseExact("29-09-1976", "dd-MM-yyyy", CultureInfo.InvariantCulture) });

            db.Genres.Add(new Genre { GenreId = 1, Name = "Роман" });
            db.Genres.Add(new Genre { GenreId = 2, Name = "Повесть" });
            db.Genres.Add(new Genre { GenreId = 3, Name = "Эпос" });
            db.Genres.Add(new Genre { GenreId = 4, Name = "Рассказ" });
            db.Genres.Add(new Genre { GenreId = 5, Name = "Опус" });
            db.Genres.Add(new Genre { GenreId = 6, Name = "Фантастика" });

            db.SaveChanges();

            db.Books.Add(new Book { BookId = 1, Name = "Кобзарь", AuthorId = 2, GenreId = 3, NumberOfPages = 656 });
            db.Books.Add(new Book { BookId = 2, Name = "Черновик", AuthorId = 5, GenreId = 6, NumberOfPages = 352 });
            db.Books.Add(new Book { BookId = 3, Name = "Капитанская дочка", AuthorId = 3, GenreId = 1, NumberOfPages = 448 });
            db.Books.Add(new Book { BookId = 4, Name = "Вечера на хуторе близ Диканьки", AuthorId = 4, GenreId = 3, NumberOfPages = 320 });
            db.Books.Add(new Book { BookId = 5, Name = "Дама с собачкой", AuthorId = 1, GenreId = 2, NumberOfPages = 656 });
            db.Books.Add(new Book { BookId = 6, Name = "Чистовик", AuthorId = 5, GenreId = 6, NumberOfPages = 450 });

            db.SaveChanges();

            base.Seed(db);
        }
    }

}
