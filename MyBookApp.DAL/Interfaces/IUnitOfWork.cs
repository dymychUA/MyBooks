using MyBookApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author> Authors { get; }
        IRepository<Book> Books { get; }
        IRepository<Genre> Genres { get; }
        void Save();
    }
}
