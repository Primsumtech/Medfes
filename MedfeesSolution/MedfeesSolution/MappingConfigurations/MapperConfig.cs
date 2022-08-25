using AutoMapper;
using MedfeesSolution.Dtos.Patient;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.MappingConfigurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateEditUserDTO, User>();
            CreateMap<Models.Patient, AddPatinetRequestDto>();
        }
    }
}
