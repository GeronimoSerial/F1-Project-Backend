using AutoMapper;
using BusinessLogicLayer.Dto;
using DataStorageLayer.DatabaseContext;
using DataStorageLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services 
{
    public class PilotService : iPilotService
    {

        private readonly F1DbContext _db;
        private readonly IMapper _mapper;


        public PilotService(F1DbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task AddPilot(PilotDto pilotDto)
        {

            var pilot = new Pilot 
            {
                FullName = pilotDto.FullName,
                Description = pilotDto.Description,
                Surname = pilotDto.Surname,
                Number = pilotDto.Number,
                Nationality = pilotDto.Nationality,
                Birthday = pilotDto.Birthday,
                PointsThisSeason = pilotDto.PointsThisSeason,
                PodiumsThisSeason = pilotDto.PodiumsThisSeason,
                TotalPoints = pilotDto.TotalPoints,
                Wins = pilotDto.Wins,
                FastestLaps = pilotDto.FastestLaps,
                Podiums = pilotDto.Podiums,
                Poles = pilotDto.Poles,
                Championships = pilotDto.Championships,
                TeamId = pilotDto.TeamId
            };
            _db.Pilots.Add(pilot);
            await _db.SaveChangesAsync();
        }
            

        

        public async Task<List<PilotDto>> GetAllPilots(FilterPilotDto filter)
        {
        /// <summary>
        /// Returns a list of pilots based on the specified filter options.
        /// </summary>
        /// <param name="filter">Filter options.</param>
        /// <returns>A list of pilots that match the filter options.</returns>
            try
            {
                // Apply filter options to query
                var pilots = await _db.Pilots
                    .Where(p =>
                        (string.IsNullOrEmpty(filter.Team) || (p.Team.Name == filter.Team)) // By team name
                        &&
                        (string.IsNullOrEmpty(filter.Nationality) || (p.Nationality == filter.Nationality)) // By nationality
                        &&
                        (filter.isChampion == null || (p.Championships > 0 == filter.isChampion)) // By if it is a champion
                    )
                    .Skip((filter.Page - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

                // Map pilots to PilotDto using AutoMapper
                var pilotsDto = new List<PilotDto>();
                pilotsDto = _mapper.Map<List<PilotDto>>(pilots);

                return pilotsDto;
            }
            catch (System.Exception)
            {
                // If any errors occur, re-throw the exception
                throw;
            }
        }


        public async Task<PilotDto> GetPilotById(int pilotId)
        {
            if (pilotId == 0) throw new Exception("Pilot ID Required");

            try 
            {
                var pilot = await _db.Pilots.FirstOrDefaultAsync(x => x.Id == pilotId);
                var pilotDto = new PilotDto();

                if (pilot != null)
                {
                    pilotDto = new PilotDto
                    {
                        FullName = pilot.FullName,
                        Description = pilot.Description,
                        Surname = pilot.Surname,
                        Number = pilot.Number,
                        Nationality = pilot.Nationality,
                        Birthday = pilot.Birthday,
                        PointsThisSeason = pilot.PointsThisSeason,
                        PodiumsThisSeason = pilot.PodiumsThisSeason,
                        TotalPoints = pilot.TotalPoints,
                        Wins = pilot.Wins,
                        FastestLaps = pilot.FastestLaps,
                        Podiums = pilot.Podiums,
                        Poles = pilot.Poles,
                        Championships = pilot.Championships,
                        TeamId = pilot.TeamId
                    };      

                }
                    return pilotDto;
            }

            catch(Exception ) 
            {
                throw;
            }
        }

        public async Task UpdatePilot(PilotDto pilotDto, int pilotId)
        {
            try
            {
                var pilot = await _db.Pilots.FirstOrDefaultAsync(x => x.Id == pilotId);

                if (pilot == null) throw new Exception("Pilot not found");

                pilot.FullName = pilotDto.FullName;
                pilot.Surname = pilotDto.Surname;
                pilot.Number = pilotDto.Number;
                pilot.Nationality = pilotDto.Nationality;
                pilot.Description = pilotDto.Description;
                pilot.Birthday = pilotDto.Birthday;
                pilot.PointsThisSeason = pilotDto.PointsThisSeason;
                pilot.PodiumsThisSeason = pilotDto.PodiumsThisSeason;
                pilot.TotalPoints = pilotDto.TotalPoints;
                pilot.Wins = pilotDto.Wins;
                pilot.FastestLaps = pilotDto.FastestLaps;
                pilot.Podiums = pilotDto.Podiums;
                pilot.Poles = pilotDto.Poles;
                pilot.Championships = pilotDto.Championships;

                //save changes
                _db.Pilots.Update(pilot);
                await _db.SaveChangesAsync();
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public async Task DeletePilot(int pilotId)
        {
            try
            {
                var pilot = await _db.Pilots.FirstOrDefaultAsync(x => x.Id == pilotId);
                if (pilot == null) throw new Exception("Pilot not found");
                _db.Pilots.Remove(pilot);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PilotStatsDto> GetPilotStats(string pilotName)
        {
            pilotName = pilotName.ToLower(); // Convertir el nombre de piloto a minúsculas

            var allPilots = await _db.Pilots.ToListAsync(); // Obtener todos los pilotos

            var pilot = allPilots.FirstOrDefault(p => p.FullName.ToLower().Contains(pilotName)); // Buscar coincidencias en FullName pasado a minusculas
            
            if(pilot == null) throw new ArgumentException("Pilot not found", nameof(pilotName));

            var pilotStatsDto = new PilotStatsDto
            {
                FullName = pilot.FullName,
                PointsThisSeason = pilot.PointsThisSeason,
                PodiumsThisSeason = pilot.PodiumsThisSeason,
                TotalPoints = pilot.TotalPoints,
                Wins = pilot.Wins,
                FastestLaps = pilot.FastestLaps,
                Podiums = pilot.Podiums,
                Poles = pilot.Poles,
                Championships = pilot.Championships,
            };
            return pilotStatsDto;
        
        }

    }   
}
