using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silver.API.Data;
using Silver.API.Dtos;
using Silver.API.Models;

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

        [HttpGet("enemy/{id}")]
        public async Task<IActionResult> GetEnemy(int id)
        {
            var enemy = await _repo.GetEnemy(id);
            
            var enemyToReturn = _mapper.Map<EnemyForDungeonMenu>(enemy);

            return Ok(enemyToReturn);
        }

        [HttpGet("encounter/{dungeonId}")]
        public async Task<IActionResult> GetEncounter(int dungeonId)
        {
            var dungeon = await _repo.GetDungeon(dungeonId);

            var EnemyList = new List<Enemy> {};

            foreach (var enemy in dungeon.Enemies)
            {
                if (!enemy.IsBoss)
                {
                    EnemyList.Add(enemy);
                }
            }

            // List<EnemyForDungeonMenu> enemyList = dungeonToReturn.Enemies.Cast<EnemyForDungeonMenu>().ToList();
            
            Random random = new Random();
            int randomEnemy = random.Next(EnemyList.Count);

            var finalEnemy = await _repo.GetEnemy(randomEnemy);
            var enemyToReturn = _mapper.Map<EnemyForEncounterDto>(finalEnemy);

            return Ok(enemyToReturn);
        }
    }
}