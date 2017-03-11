using AutoMapper;
using MyBookApp.BLL.DTO;
using MyBookApp.BLL.Interfaces;
using MyBookApp.WEB.Models;
using MyBookApp.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyBookApp.WEB.Controllers
{
    public class BookController : Controller
    {
        IMyBooksService myBooksService;
        IMapper bookMapper = BookMapperDefaultProfile.Mapper;

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public BookController(IMyBooksService serv)
        {
            myBooksService = serv;
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AuthorDTO authorDTO = myBooksService.GetAuthor(id);
            if (authorDTO == null)
            {
                return HttpNotFound();
            }

            IEnumerable<GenreDTO> genresDTO = myBooksService.GetGenres();

            var genres = bookMapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(genresDTO);
            var author = bookMapper.Map<AuthorDTO, AuthorViewModel>(authorDTO);

            ViewBag.Genres = new SelectList(genres, "GenreId", "Name", 1);

            return View("Edit", author);
        }

        private IEnumerable<BookViewModel> GetAuthorsBooks(int? id)
        {
            IEnumerable<BookDTO> booksDTO = from b in myBooksService.GetBooks()
                                            where b.AuthorId == id
                                            select b;

            return bookMapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(booksDTO);
        }

        public ActionResult NewBooks(BookViewModel[] newBooks)
        {
            int id = 0;

            if (newBooks != null)
            {
                foreach (var item in newBooks)
                {
                    id = item.AuthorId;
                    myBooksService.AddBook(bookMapper.Map<BookViewModel, BookDTO>(item));
                }
            }

            var books = GetAuthorsBooks(id);
            return PartialView("BooksData", books);
        }

        public ActionResult BooksData(int? id)
        {
            var books = GetAuthorsBooks(id);
            return PartialView(books);
        }
    }
}