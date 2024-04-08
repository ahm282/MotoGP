using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class ListTicketsViewModel
    {
        public int TicketID { get; set; }
        public int RaceID { get; set; }
        public List<Ticket> Tickets { get; set; }
        public SelectList RacesSelectList { get; set; }
        public Race SelectedRace;
    }
}