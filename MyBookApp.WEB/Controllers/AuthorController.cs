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
    public class AuthorController : Controller
    {
        IMyBooksService myBooksService;
        IMapper bookMapper = BookMapperDefaultProfile.Mapper;

        public AuthorController(IMyBooksService serv)
        {
            myBooksService = serv;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorId,LastName,FirstName,MiddleName,BirthDate")] AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var authorDTO = bookMapper.Map<AuthorViewModel, AuthorDTO>(author);
                myBooksService.AddAuthor(authorDTO);
                return RedirectToAction("Index", "Home");
            }

            return View(author);
        }

        public ActionResult Delete(int? id)
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

            var author = bookMapper.Map<AuthorDTO, AuthorViewModel>(authorDTO);

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorDTO authorDto = myBooksService.GetAuthor(id);

            myBooksService.DeleteAuthor(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorDTO author = myBooksService.GetAuthor(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(bookMapper.Map<AuthorDTO, AuthorViewModel>(author));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorId,LastName,FirstName,MiddleName,BirthDate")] AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                myBooksService.UpdateAuthor(bookMapper.Map<AuthorViewModel, AuthorDTO>(author));
                return RedirectToAction("Index", "Home");
            }
            return View(author);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                myBooksService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}