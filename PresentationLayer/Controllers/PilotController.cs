using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using DataStorageLayer.DatabaseContext;
using DataStorageLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Infrastucture.Dto;

namespace PresentationLayer.Controller
{

    [Route("api/[controller]")]
    [ApiController]

    public class PilotController: ControllerBase
    {
        private readonly iPilotService _pilotService;


        public PilotController (iPilotService pilotService)
        {
            _pilotService = pilotService;

        }


      
        [HttpPost("AddPilot")]
        public async Task<ActionResult> AddPilot([FromForm]AddPilotDto pilotDto)
        {
            try
            {
                var pilot = new PilotDto
                {
                    FullName = pilotDto.FullName,
                    Surname = pilotDto.Surname,
                    Number = pilotDto.Number,
                    Nationality = pilotDto.Nationality,
                    Description = pilotDto.Description,
                    Birthday = pilotDto.Birthday,
                    PointsThisSeason = pilotDto.PointsThisSeason,
                    PodiumsThisSeason = pilotDto.PodiumsThisSeason,
                    Podiums = pilotDto.Podiums,
                    TotalPoints = pilotDto.TotalPoints,
                    Wins = pilotDto.Wins,
                    Championships = pilotDto.Championships,
                    FastestLaps = pilotDto.FastestLaps,
                    Poles = pilotDto.Poles
                };
                await _pilotService.AddPilot(pilot);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("GetAllPilots")]
        public async Task<ActionResult> GetAllPilots([FromQuery] FilterPilotDto filter)
        {
            var result = await _pilotService.GetAllPilots(filter);
            return Ok(result);
        }


        [HttpGet("GetPilotById/{pilotId}")]
        

            public async Task<ActionResult> GetPilotById(int pilotId) 
            {
                var pilot = await _pilotService.GetPilotById(pilotId);

                return Ok(pilot);
            }


//         [HttpGet("GetPilotsStats/{pilotId}")]

//         public async Task<ActionResult<Pilot>> GetPilotsStats(int pilotId)
//         {
//             var pilot = await _db.Pilots.FirstOrDefaultAsync(x=>x.Id == pilotId);
//             return Ok(pilot);


//         }
        
//     }
// }
    }
}