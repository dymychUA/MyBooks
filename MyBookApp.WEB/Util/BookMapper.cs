using AutoMapper;
using AutoMapper.Configuration;
using MyBookApp.BLL.DTO;
using MyBookApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookApp.WEB.Util
{
    public static class BookMapperDefaultProfile
    {
        public static IMapper Mapper { get; set; }

        static BookMapperDefaultProfile()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorDTO, AuthorViewModel>();
                cfg.CreateMap<BookDTO, BookViewModel>();
                cfg.CreateMap<GenreDTO, GenreViewModel>();
                cfg.CreateMap<AuthorViewModel, AuthorDTO>();
                cfg.CreateMap<BookViewModel, BookDTO>();
                cfg.CreateMap<GenreViewModel, GenreDTO>();
            });

            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}