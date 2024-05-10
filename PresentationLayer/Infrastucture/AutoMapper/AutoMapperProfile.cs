using AutoMapper;
using BusinessLogicLayer.Dto;
using DataStorageLayer.Entities;

namespace PresentationLayer.Infrastucture.AutoMapper
{
    public class AutoMapperProfile: Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Pilot, PilotDto>();
            
        }
    }

}

