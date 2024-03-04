namespace MotoGP.Models
{
    public class Race
    {
        public int raceID { get; set; }
        public string name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Race(int raceID, string name, int x, int y)
        {
            this.raceID = raceID;
            this.name = name;
            X = x;
            Y = y;
        }
    }

}
