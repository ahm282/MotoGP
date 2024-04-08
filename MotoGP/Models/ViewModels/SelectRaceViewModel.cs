using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class SelectRaceViewModel
    {
        public int RaceId;
        public List<Race> Races;
        public SelectList RacesSelectList { get; set; }
        public Race SelectedRace;
    }
}
