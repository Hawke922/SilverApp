using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silver.API.Data;
using Silver.API.Dtos;

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
    }
}