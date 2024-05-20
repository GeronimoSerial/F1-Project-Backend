using AutoMapper;
using BusinessLogicLayer.Dto;
using DataStorageLayer.Entities;
using PresentationLayer.Infrastucture.Dto;

namespace PresentationLayer.Infrastucture.AutoMapper
{
    public class AutoMapperProfile: Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Pilot, PilotDto>();

            CreateMap<Team, TeamDto>();

            CreateMap<Team, AddTeamDto>();
            
        }
    }

}

