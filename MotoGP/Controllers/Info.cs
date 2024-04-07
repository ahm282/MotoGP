using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;
using MotoGP.Data;
using Microsoft.EntityFrameworkCore;

namespace MotoGP.Controllers
{
    public class Info : Controller
    {
        private readonly GPContext _context;

        public Info(GPContext context)
        {
            _context = context;
        }

        public static string GetImagePath(int bannerID)
        {
            var banners = new List<String>
            { "bannerRaces.jpg", "bannerRiders.jpg", "bannerTeams.jpg", "bannerTickets.jpg" };
            var bannerNr = bannerID;
            var imagePath = "/images/banners/";

            // Set the image path based on the value of BannerNr
            switch (bannerNr)
            {
                case 0:
                    imagePath += "bannerRaces.jpg";
                    break;
                case 1:
                    imagePath += "bannerRiders.jpg";
                    break;
                case 2:
                    imagePath += "bannerTeams.jpg";
                    break;
                case 3:
                    imagePath += "bannerTickets.jpg";
                    break;
                default:
                    imagePath += "default-banner.jpg"; // Default banner if BannerNr is out of range
                    break;
            }
            return imagePath;
        }

        public IActionResult ListRaces(int bannerID)
        {
            ViewData["BannerPath"] = GetImagePath(bannerID);
            ViewData["Title"] = "List Races";
            var races = _context.Races.OrderBy(r => r.Date);

            return View(races.ToList());
        }

        public IActionResult BuildMap()
        {
            ViewData["BannerPath"] = GetImagePath(0);
            ViewData["Title"] = "Races on map";
            var races = _context.Races.OrderBy(r => r.Name);

            return View(races.ToList());
        }

        public IActionResult ShowRace(int id)
        {
            Race selectedRace = _context.Races.SingleOrDefault(r => r.RaceID == id);
            Console.WriteLine("SelectedRace: " + id);

            if (selectedRace != null)
            {
                Console.WriteLine("SelectedRace: " + id);
                ViewData["BannerPath"] = GetImagePath(0);
                return View(selectedRace);
            }
            else
            {
                // Handle case where race with specified raceID is not found
                // For example, redirect to an error page or display a message to the user
                return NotFound();
            }
        }

        public IActionResult ListRiders()
        {
            ViewData["BannerPath"] = GetImagePath(1);
            ViewData["Title"] = "List Riders";
            var riders = _context.Riders.OrderBy(r => r.Number);

            return View(riders.ToList());
        }
    }
}
