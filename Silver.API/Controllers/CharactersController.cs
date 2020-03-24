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

            if (characterForCreateDto.Class == "warrior") {
                characterToCreate.Name = characterForCreateDto.Name;
                characterToCreate.Class = characterForCreateDto.Class;
                characterToCreate.PictureUrl = characterForCreateDto.PictureUrl;
                characterToCreate.UserId = characterForCreateDto.UserId;
                characterToCreate.Hp = 100;
                characterToCreate.FastAttack = 10;
                characterToCreate.StrongAttack = 15;
                characterToCreate.SpecialAttack = 10;
                characterToCreate.FastDefense = 2;
                characterToCreate.StrongDefense = 1;
                characterToCreate.SpecialDefense = 0;
                characterToCreate.ClassIcon = "ra-axe";
                characterToCreate.FastAttAbility = "Piercing Strike";
                characterToCreate.StrongAttAbility = "Decapitate";
                characterToCreate.SpecialAttAbility = "Grappling Hook";
                characterToCreate.fastDefAbility = "Heavy Armor";
                characterToCreate.StrongDefAbility = "Shield Wall";
                characterToCreate.SpecialDefAbility = "Ignore Pain";
                characterToCreate.FastAttAbilityIcon = "ra-drill";
                characterToCreate.StrongAttAbilityIcon = "ra-decapitation";
                characterToCreate.SpecialAttAbilityIcon = "ra-grappling-hook";
                characterToCreate.fastDefAbilityIcon = "ra-knight-helmet";
                characterToCreate.StrongDefAbilityIcon = "ra-castle-flag";
                characterToCreate.SpecialDefAbilityIcon = "ra-player-pyromaniac";
            } else if (characterForCreateDto.Class == "rogue") {
                characterToCreate.Name = characterForCreateDto.Name;
                characterToCreate.Class = characterForCreateDto.Class;
                characterToCreate.PictureUrl = characterForCreateDto.PictureUrl;
                characterToCreate.UserId = characterForCreateDto.UserId;
                characterToCreate.Hp = 100;
                characterToCreate.FastAttack = 15;
                characterToCreate.StrongAttack = 10;
                characterToCreate.SpecialAttack = 10;
                characterToCreate.FastDefense = 1;
                characterToCreate.StrongDefense = 0;
                characterToCreate.SpecialDefense = 2;
                characterToCreate.ClassIcon = "ra-plain-dagger";
                characterToCreate.FastAttAbility = "Knife Throw";
                characterToCreate.StrongAttAbility = "Ambush";
                characterToCreate.SpecialAttAbility = "Trap";
                characterToCreate.fastDefAbility = "Adrenaline Rush";
                characterToCreate.StrongDefAbility = "Dodge";
                characterToCreate.SpecialDefAbility = "Vanish";
                characterToCreate.FastAttAbilityIcon = "ra-kunai";
                characterToCreate.StrongAttAbilityIcon = "ra-blade-bite";
                characterToCreate.SpecialAttAbilityIcon = "ra-bear-trap";
                characterToCreate.fastDefAbilityIcon = "ra-defibrillate";
                characterToCreate.StrongDefAbilityIcon = "ra-player-dodge";
                characterToCreate.SpecialDefAbilityIcon = "ra-nuclear";
            } else {
                characterToCreate.Name = characterForCreateDto.Name;
                characterToCreate.Class = characterForCreateDto.Class;
                characterToCreate.PictureUrl = characterForCreateDto.PictureUrl;
                characterToCreate.UserId = characterForCreateDto.UserId;
                characterToCreate.Hp = 100;
                characterToCreate.FastAttack = 10;
                characterToCreate.StrongAttack = 10;
                characterToCreate.SpecialAttack = 15;
                characterToCreate.FastDefense = 0;
                characterToCreate.StrongDefense = 2;
                characterToCreate.SpecialDefense = 1;
                characterToCreate.ClassIcon = "ra-crystal-wand";
                characterToCreate.FastAttAbility = "Lightning Bolt";
                characterToCreate.StrongAttAbility = "Inferno";
                characterToCreate.SpecialAttAbility = "Freeze";
                characterToCreate.fastDefAbility = "Divert";
                characterToCreate.StrongDefAbility = "Flame Shield";
                characterToCreate.SpecialDefAbility = "Barrier";
                characterToCreate.FastAttAbilityIcon = "ra-focused-lightning";
                characterToCreate.StrongAttAbilityIcon = "ra-burning-meteor";
                characterToCreate.SpecialAttAbilityIcon = "ra-frost-emblem";
                characterToCreate.fastDefAbilityIcon = "ra-divert";
                characterToCreate.StrongDefAbilityIcon = "ra-burning-book";
                characterToCreate.SpecialDefAbilityIcon = "ra-barrier";
            }

            var createdCharacter = await _repo.CreateCharacter(characterToCreate);

            return StatusCode(201);
        }
    }
}