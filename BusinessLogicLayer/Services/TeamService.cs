using AutoMapper;
using BusinessLogicLayer.Dto;
using DataStorageLayer.DatabaseContext;
using DataStorageLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TeamService : iTeamService
    {
        private readonly F1DbContext _db;
        private readonly IMapper _mapper;
        



        public TeamService(F1DbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddTeam(TeamDto teamDto)
        {
            var team = new Team
            {
                Id = teamDto.Id,
                Name = teamDto.Name,
                Nationality = teamDto.Nationality,
                HighestPosition = teamDto.HighestPosition,
                Championships = teamDto.Championships,
                Poles = teamDto.Poles,
                Chassis = teamDto.Chassis,
                Engine = teamDto.Engine,
                TeamChief = teamDto.TeamChief,
                FastestLaps = teamDto.FastestLaps

            };
            _db.Teams.Add(team);
            await _db.SaveChangesAsync();
        }
        public async Task<TeamDto> GetTeam(int teamId)
        {
           
            var pilots = await _db.Pilots.Where(x => x.TeamId == teamId).ToListAsync();
            
            var pilotsDto = new List<PilotDto>();
            pilotsDto = _mapper.Map<List<PilotDto>>(pilots);
           
            //var pilotsDto = pilots.Select(p => new PilotDto
            //{
            //    Id = p.Id,
            //    FullName = p.FullName,
            //    Surname = p.Surname,
            //    Number = p.Number,
            //    Nationality = p.Nationality,
            //    Description = p.Description,
            //    Birthday = p.Birthday,
            //    PointsThisSeason = p.PointsThisSeason,
            //    PodiumsThisSeason = p.PodiumsThisSeason,
            //    Podiums = p.Podiums,
            //    TotalPoints = p.TotalPoints,
            //    Wins = p.Wins,
            //    Championships = p.Championships,
            //    FastestLaps = p.FastestLaps,
            //    Poles = p.Poles,
            //    TeamId = p.TeamId
            //}).ToList();

            // var pilotsDtos = new List<PilotDto>();


            var team = await _db.Teams.FirstOrDefaultAsync(x => x.Id == teamId);
            if (team == null) throw new Exception("Team not found");
         

                var teamDto = new TeamDto 
                {
                    Id = team.Id,
                    Name = team.Name,
                    Nationality = team.Nationality,
                    HighestPosition = team.HighestPosition,
                    Championships = team.Championships,
                    Poles = team.Poles,
                    Chassis = team.Chassis,
                    Engine = team.Engine,
                    TeamChief = team.TeamChief,
                    FastestLaps = team.FastestLaps,
                    Pilots = pilotsDto
                };

            return teamDto;
        }
            
            
    }
}

