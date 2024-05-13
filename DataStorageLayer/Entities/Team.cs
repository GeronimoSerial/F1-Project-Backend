namespace DataStorageLayer.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Chassis { get; set; }
        public string Engine { get; set; }
        public string TeamChief { get; set; }
        public int Championships { get; set; }
        public string HighestPosition { get; set; }
        public int Poles { get; set; }
        public int FastestLaps { get; set; }
        public List<Pilot> Pilots { get; set; }
    }
}