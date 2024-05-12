using BusinessLogicLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public interface iTeamService
    {
        public Task AddTeam (TeamDto teamDto);
        public Task<TeamDto> GetTeam (int teamId);
    }
}
