using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = BookCatalog.Model;
using dto = BookCatalog.Service.DTO;

namespace BookCatalog.Service
{
    public class AutomapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<model.Book, dto.Book>().ReverseMap();
            });

            return config;
        }
    }
}
