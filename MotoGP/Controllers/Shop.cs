using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;

namespace MotoGP.Controllers
{
    public class Shop : Controller
    {
        private readonly GPContext _context;

        public Shop(GPContext context)
        {
            _context = context;
        }

        public IActionResult OrderTicket(int bannerNr) {
            ViewData["BannerPath"] = Info.GetImagePath(bannerNr);
            ViewData["Title"] = "Order Tickets";

            var countries = _context.Countries.OrderBy(c => c.Name).ToList();
            countries.Insert(0, new Country { CountryID = 0, Name = "Select Country" });
            ViewData["Countries"] = new SelectList(countries, "CountryID", "Name");

            var races = _context.Races.OrderBy(r => r.Name).ToList();
            races.Insert(0, new Race { RaceID = 0, Name = "Select Race" }); // Adjust the placeholder text as needed
            ViewData["Races"] = new SelectList(races, "RaceID", "Name");

            return View();
        }

        public IActionResult ConfirmOrder(int id)
        {
            ViewData["Title"] = "Confirmation";
            ViewData["BannerPath"] = Info.GetImagePath(3);
            ViewData["CurrentDate"] = DateTime.Now.ToString("dd/MM/yyyy");

            var ticket = _context.Tickets
                                .Include(t => t.Race)
                                .FirstOrDefault(t => t.TicketID == id);


            return View(ticket);
        }

        // POST: Shop/Create
        public IActionResult Create([Bind("Name, Email, Address, Number, CountryID, RaceID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.OrderDate = DateTime.Now;
                ticket.Paid = false;

                // Save the ticket to the database
                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder", new {id = ticket.TicketID});
            }

            return View(ticket);
        }

        public IActionResult ListTickets(int raceID = 0)
        {
            ViewData["Title"] = "Tickets";
            ViewData["BannerPath"] = Info.GetImagePath(3);

            var races = _context.Races.OrderBy(r => r.Name).ToList();

            var ListTicketsVM= new ListTicketsViewModel();
            ListTicketsVM.RacesSelectList = new SelectList(races, "RaceID", "Name");

            if (raceID != 0)
            {
                ListTicketsVM.SelectedRace = _context.Races.Where(r => r.RaceID == raceID).First();
                var tickets = _context.Tickets.OrderBy(t => t.OrderDate).Where(t => t.RaceID == raceID).ToList();
                ListTicketsVM.Tickets = tickets;
            }
            else
            {
                ListTicketsVM.SelectedRace = _context.Races.OrderBy(r => r.RaceID).First();
                var tickets = _context.Tickets.OrderBy(t => t.OrderDate).ToList();
                ListTicketsVM.Tickets = tickets;
            }

            return View(ListTicketsVM);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
