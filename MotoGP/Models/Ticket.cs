namespace MotoGP.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public int RaceID { get; set; }
        public int Number { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }

        public Country? Country { get; set; }
        public Race? Race { get; set; }

        public Ticket()
        {
        }

        public Ticket(string name, string email, string address, int countryID, int raceID, int number, DateTime orderDate, bool paid)
        {
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.CountryID = countryID;
            this.RaceID = raceID;
            this.Number = number;
            this.OrderDate = orderDate;
            this.Paid = paid;
        }
    }
}
