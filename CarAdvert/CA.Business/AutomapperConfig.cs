using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CA.Data.Entities;
using CA.Business.DTOs;

namespace CA.Business
{
    public class AutomapperConfig
    {
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static IMapper Mapper { get; private set; }

        public static void Configure()
        {
            MapperConfiguration = new MapperConfiguration(Configure);
            Mapper = MapperConfiguration.CreateMapper();
        }

        private static void Configure(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMissingTypeMaps = true;
            mapperConfiguration.CreateMap<CarAdvert, CarAdvertDto>().ReverseMap();
        }
    }
}
