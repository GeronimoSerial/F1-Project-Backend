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

        public TeamController(iTeamService teamService)
        {
            _teamService = teamService;
          
        }

        [HttpPost("AddTeam")]
        public async Task<ActionResult> AddTeam([FromForm]AddTeamDto teamDto)
        {
            var team = new TeamDto 
            {
                Name = teamDto.Name,
                Nationality = teamDto.Nationality,
                TeamChief = teamDto.TeamChief,
                Chassis = teamDto.Chassis,
                Engine = teamDto.Engine,
                Championships = teamDto.Championships,
                HighestPosition = teamDto.HighestPosition,
                Poles = teamDto.Poles,
                FastestLaps = teamDto.FastestLaps
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
}