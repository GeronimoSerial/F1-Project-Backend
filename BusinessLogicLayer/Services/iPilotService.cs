using BusinessLogicLayer.Dto;
using DataStorageLayer.Entities;

namespace BusinessLogicLayer.Services
{

    public interface iPilotService
    {
        Task AddPilot(PilotDto pilotDto);
        Task<List<PilotDto>> GetAllPilots(FilterPilotDto filter);
        Task<PilotDto> GetPilotById(int pilotId);
        Task UpdatePilot(UpdatePilotDto pilot, int pilotId);
        Task DeletePilot(int pilotId);
        Task<PilotStatsDto> GetPilotStats(string pilotName);

        //Task <List<Pilot>> GetPilotsByTeamId(int teamId);



    }

}
