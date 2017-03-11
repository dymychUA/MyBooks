using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBookApp.BLL.Interfaces;
using MyBookApp.BLL.DTO;
using MyBookApp.WEB.Models;
using AutoMapper;
using MyBookApp.BLL.Infrastructure;
using System.Net;
using MyBookApp.WEB.Util;


namespace MyBookApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IMyBooksService myBooksService;
        IMapper bookMapper = BookMapperDefaultProfile.Mapper;

        public HomeController(IMyBooksService serv)
        {
            myBooksService = serv;
        }

        public ActionResult Index()
        {
            var authors = bookMapper.Map<IEnumerable<AuthorDTO>, List<AuthorViewModel>>(myBooksService.GetAuthors());
            return View(authors);
        }

        protected override void Dispose(bool disposing)
        {
            myBooksService.Dispose();
            base.Dispose(disposing);
        }

    }
}