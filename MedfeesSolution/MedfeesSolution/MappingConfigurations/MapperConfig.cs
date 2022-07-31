using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using AutoMapper;
namespace MedfeesSolution.MappingConfigurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateEditUserDTO, User>();
            
        }
    }
}
