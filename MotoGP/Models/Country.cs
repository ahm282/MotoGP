using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGP.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(int countryID, string name)
        {
            this.CountryID = countryID;
            this.Name = name;
        }
    }
}
