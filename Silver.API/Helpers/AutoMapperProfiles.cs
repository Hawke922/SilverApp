using AutoMapper;
using Silver.API.Dtos;
using Silver.API.Models;

namespace Silver.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForMenusDto>();
            CreateMap<Character, CharacterDto>();
        }
    }
}