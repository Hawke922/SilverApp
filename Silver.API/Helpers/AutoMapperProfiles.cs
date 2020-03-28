using System.Linq;
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
            CreateMap<Character, CharacterForMenuDto>().ForMember(dto => dto.Abilities, opt => opt.MapFrom(x => x.AbilityCharacters.Select(y => y.Ability)));
            CreateMap<Dungeon, DungeonForMenuDto>();
            CreateMap<Enemy, EnemyForDungeonMenu>();
            CreateMap<Ability, AbilitiesForCharacterMenuDto>();
        }
    }
}