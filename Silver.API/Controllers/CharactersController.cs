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
            
            var characterToReturn = _mapper.Map<CharacterDto>(character);

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
            }

            var createdCharacter = await _repo.CreateCharacter(characterToCreate);

            return StatusCode(201);
        }
    }
}