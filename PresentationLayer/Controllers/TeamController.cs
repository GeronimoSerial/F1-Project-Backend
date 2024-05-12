using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using DataStorageLayer.DatabaseContext;
using DataStorageLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Infrastucture.Dto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly iTeamService _teamService;
        private readonly F1DbContext _db;

        public TeamController(F1DbContext db, iTeamService teamService)
        {
            _teamService = teamService;
            _db = db;
        }

        [HttpPost("AddTeam")]
        public async Task<ActionResult> AddTeam(AddTeamDto teamDto)
        {
            var team = new TeamDto 
            {
                Id = teamDto.Id,
                Name = teamDto.Name,
                Nationality = teamDto.Nationality,
                Wins = teamDto.Wins,
                Championships = teamDto.Championships,
                
            };
            await _teamService.AddTeam(team);
            return Ok();
        }

        [HttpGet("GetTeam/{teamId}")]
        public async Task<ActionResult<TeamDto>> GetTeam(int teamId)
        {
            var team = await _teamService.GetTeam(teamId);
            return Ok(team);
        }
    }
    //    [HttpGet]
    //    public ActionResult<IEnumerable<string>> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    [HttpGet("{id}")]
    //    public ActionResult<string> Get(int id)
    //    {
    //        return "value";
    //    }

    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    //}
}