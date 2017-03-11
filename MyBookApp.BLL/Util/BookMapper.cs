using AutoMapper;
using MyBookApp.BLL.DTO;
using MyBookApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookApp.BLL.Util
{
    public static class BookMapperDefaultProfile
    {
        public static IMapper Mapper { get; set; }

        static BookMapperDefaultProfile()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorDTO, Author>();
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<GenreDTO, Genre>();
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<Genre, GenreDTO>();
            });

            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}
