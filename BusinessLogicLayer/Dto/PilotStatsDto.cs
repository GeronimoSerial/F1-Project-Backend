﻿using DataStorageLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto
{
    public class PilotStatsDto
    {
        public string FullName { get; set; }
        public int PointsThisSeason { get; set; }
        public int PodiumsThisSeason { get; set; }
        public int TotalPoints { get; set; }
        public int Wins { get; set; }
        public int FastestLaps { get; set; }
        public int Podiums { get; set; }
        public int Poles { get; set; }
        public int Championships { get; set; }

    }
}
