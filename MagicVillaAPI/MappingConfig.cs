using AutoMapper;
using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dtos;

namespace MagicVillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();

            //you can use reverse map or we can map them again as below 
            //CreateMap<VillaDto, Villa>();
        }
    }
}
