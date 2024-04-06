namespace MotoGP.Models
{
    public class Race
    {
        public int RaceID { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Country { get; set; }
        public string Description{ get; set; }
        public int Length { get; set; }
        public DateTime Date { get; set; }

        public Race() { }

        public Race(int raceID, string name, int x, int y, string country, string description, int length, DateTime date)
        {
            this.RaceID = raceID;
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Country = country;
            this.Description = description;
            this.Length = length;
            this.Date = date;
        }
    }
}
