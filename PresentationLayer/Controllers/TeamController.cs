using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public TeamController(iTeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
          
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

        [HttpPut("UpdateTeam/{teamId}")]
        public async Task <ActionResult> UpdateTeam(int teamId, AddTeamDto teamDto)
        {
            try
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
                await _teamService.UpdateTeam(team, teamId);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTeam/{teamId}")]
        public async Task<ActionResult<TeamDto>> GetTeam(int teamId)
        {
            var team = await _teamService.GetTeam(teamId);
            return Ok(team);
        }
    }
}