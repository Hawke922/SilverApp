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
            CreateMap<Enemy, EnemyForDungeonMenu>().ForMember(dto => dto.Abilities, opt => opt.MapFrom(x => x.EnemyAbilities.Select(y => y.Ability)));
            CreateMap<Enemy, EnemyForEncounterDto>().ForMember(dto => dto.Abilities, opt => opt.MapFrom(x => x.EnemyAbilities.Select(y => y.Ability)));
            CreateMap<Dungeon, DungeonForMenuDto>();
            CreateMap<Dungeon, DungeonForEncounterDto>();
            CreateMap<Ability, AbilitiesForCharacterMenuDto>();
            CreateMap<Area, AreaForDungeonMenuDto>();
            CreateMap<Progress, ProgressForMenuDto>();
            CreateMap<DungeonProgress, DungeonProgressForMenuDto>();
            CreateMap<AreaProgress, AreaProgressForMenuDto>();
        }
    }
}