using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silver.API.Data;
using Silver.API.Dtos;

namespace Silver.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DungeonController : ControllerBase
    {
        private readonly IGameRepository _repo;
        private readonly IMapper _mapper;
        public DungeonController(IGameRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDungeon(int id)
        {
            var dungeon = await _repo.GetDungeon(id);
            
            var dungeonToReturn = _mapper.Map<DungeonForMenuDto>(dungeon);

            return Ok(dungeonToReturn);
        }
    }
}