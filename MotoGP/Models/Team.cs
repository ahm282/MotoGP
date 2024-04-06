using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGP.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public Team()
        {
        }

        public Team(int teamID, string name, string logo)
        {
            this.TeamID = teamID;
            this.Name = name;
            this.Logo = logo;
        }
    }
}
