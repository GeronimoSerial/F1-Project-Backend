namespace DataStorageLayer.Entities
{
    public class Team
    {
        public string Name { get; set; }

        public string Nationality { get; set; }
        public int Id { get; set; }
        public int Wins { get; set; }
        public int Championships { get; set; }
        public List<Pilot> Pilots { get; set; }
    }
}