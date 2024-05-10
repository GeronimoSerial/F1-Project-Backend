using BusinessLogicLayer.Dto;
using DataStorageLayer.Entities;

namespace BusinessLogicLayer.Services
{

    public interface iPilotService
    {
        Task AddPilot(PilotDto pilotDto);
        Task<List<PilotDto>> GetAllPilots(FilterPilotDto filter);
        Task<PilotDto> GetPilotById(int pilotId);
        // Task<Pilot> UpdatePilot(Pilot pilot);
        // Task<Pilot> GetPilotsStats(int pilotId);

        //Task <List<Pilot>> GetPilotsByTeamId(int teamId);



    }

}
