namespace MotoGP.Models
{
    public class Rider
    {
        public int RiderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamID { get; set; }
        public int CountryID { get; set; }
        public string Bike { get; set; }
        public int Number { get; set; }

        public Country? country { get; set; }
        public Team? team { get; set; }


        public Rider()
        {
        }

        public Rider(int riderID, string firstName, string lastName, int teamID, int countryID, string bike, int number)
        {
            this.RiderID = riderID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.TeamID = teamID;
            this.CountryID = countryID;
            this.Bike = bike;
            this.Number = number;
        }
    }
}
