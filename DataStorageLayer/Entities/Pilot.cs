
namespace DataStorageLayer.Entities
{
    public class Pilot
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Surname { get; set; }
        public int Number { get; set; }
        public string Nationality { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public int Podiums { get; set; }
        public float PointsThisSeason { get; set; }
        public float TotalPoints { get; set; }
        public int Wins { get; set; }
        public string HighestPosition { get; set; }
        public int Championships { get; set; }
        public int FastestLaps { get; set; }
        public int Poles { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }


    }
}