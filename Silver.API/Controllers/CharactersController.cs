using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silver.API.Data;
using Silver.API.Dtos;
using Silver.API.Models;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        private readonly IGameRepository _repo;
        private readonly IMapper _mapper;
        public CharactersController(IGameRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPatch("select")]
        public async Task<IActionResult> SelectCharacter(CharacterSelectionDto characterSelectionDto)
        {
            var character = await _repo.GetCharacter(characterSelectionDto.CharacterId);
            var user = await _repo.GetUser(characterSelectionDto.UserId);
            user.ActiveCharacterId = characterSelectionDto.CharacterId;
            await _repo.SaveAll();
            var characterToReturn = _mapper.Map<CharacterForMenuDto>(character);

            return Ok(characterToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacter(int id)
        {
            var character = await _repo.GetCharacter(id);
            var characterToReturn = _mapper.Map<CharacterForMenuDto>(character);

            return Ok(characterToReturn);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChar(CharacterForCreateDto characterForCreateDto)
        {
            characterForCreateDto.Name = characterForCreateDto.Name.ToLower();

            if (await _repo.CharacterExists(characterForCreateDto.Name))
                return BadRequest("Name already taken");
            
            var characterToCreate = new Character {};
            characterToCreate.Name = characterForCreateDto.Name;
            characterToCreate.Class = characterForCreateDto.Class;
            characterToCreate.PictureUrl = characterForCreateDto.PictureUrl;
            characterToCreate.UserId = characterForCreateDto.UserId;
            characterToCreate.ActiveDungeonId = 1;
            characterToCreate.Hp = 100;
            
            characterToCreate.Progress = new Progress {};
            characterToCreate.Progress.Character = characterToCreate;
            characterToCreate.Progress.DungeonProgress = new Collection<DungeonProgress> {};
            characterToCreate.Progress.DungeonProgress.Add (
                new DungeonProgress {
                    DungeonId = 1,
                    Explored = 0,
                    Progress = characterToCreate.Progress
                }
            );
            characterToCreate.Progress.AreaProgress = new Collection<AreaProgress> {};
            int counter = 1;
            while (counter < 4)
            {
                characterToCreate.Progress.AreaProgress.Add (
                    new AreaProgress {
                        AreaId = counter,
                        DungeonId = 1,
                        Explored = 0,
                        Progress = characterToCreate.Progress
                    }
                );
                counter++;
            };

            if (characterForCreateDto.Class == "warrior") {
                characterToCreate.FastAttack = 10;
                characterToCreate.StrongAttack = 15;
                characterToCreate.SpecialAttack = 10;
                characterToCreate.FastDefense = 2;
                characterToCreate.StrongDefense = 1;
                characterToCreate.SpecialDefense = 0;
                characterToCreate.ClassIcon = "ra-axe";
                int[] warriorAbilities = {1, 2, 3, 10, 11, 12};
                characterToCreate.AbilityCharacters = new Collection<AbilityCharacter> {};
                foreach (var ability in warriorAbilities) {
                    characterToCreate.AbilityCharacters.Add (
                        new AbilityCharacter {
                            AbilityId = ability,
                            Character = characterToCreate
                        }
                    );
                }
                
            } else if (characterForCreateDto.Class == "rogue") {
                characterToCreate.FastAttack = 15;
                characterToCreate.StrongAttack = 10;
                characterToCreate.SpecialAttack = 10;
                characterToCreate.FastDefense = 1;
                characterToCreate.StrongDefense = 0;
                characterToCreate.SpecialDefense = 2;
                characterToCreate.ClassIcon = "ra-plain-dagger";
                int[] rogueAbilities = {4, 5, 6, 13, 14, 15};
                characterToCreate.AbilityCharacters = new Collection<AbilityCharacter> {};
                foreach (var ability in rogueAbilities) {
                    characterToCreate.AbilityCharacters.Add (
                        new AbilityCharacter {
                            AbilityId = ability,
                            Character = characterToCreate
                        }
                    );
                }
                
            } else {
                characterToCreate.FastAttack = 10;
                characterToCreate.StrongAttack = 10;
                characterToCreate.SpecialAttack = 15;
                characterToCreate.FastDefense = 0;
                characterToCreate.StrongDefense = 2;
                characterToCreate.SpecialDefense = 1;
                characterToCreate.ClassIcon = "ra-crystal-wand";           
                int[] mageAbilities = {7, 8, 9, 16, 17, 18};
                characterToCreate.AbilityCharacters = new Collection<AbilityCharacter> {};
                foreach (var ability in mageAbilities) {
                    characterToCreate.AbilityCharacters.Add (
                        new AbilityCharacter {
                            AbilityId = ability,
                            Character = characterToCreate
                        }
                    );
                }
                
            }

            var createdCharacter = await _repo.CreateCharacter(characterToCreate);

            return StatusCode(201);
        }
    }
}