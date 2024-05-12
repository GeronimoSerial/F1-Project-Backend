using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStorageLayer.Entities;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto
{
    public class TeamDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Wins { get; set; }
        public int Championships { get; set; }
        public List<PilotDto> Pilots {get; set;}
        

    }
}
