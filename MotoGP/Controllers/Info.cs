using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;

namespace MotoGP.Controllers
{
    public class Info : Controller
    {
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

            return View();
        }

        public IActionResult BuildMap()
        {
            List<Race> races = new List<Race>();
            //Race Assen = new(1, "Assen", 517, 19);
            //Race Losail = new(2, "Losail Circuit", 859, 249);
            //Race Rio = new(3, "Autódromo Termas de Río Hondo", 194, 428);
            
            //races.Add(Assen);
            //races.Add(Losail);
            //races.Add(Rio);

            ViewData["Races"] = races;
            ViewData["BannerPath"] = GetImagePath(0);
            ViewData["Title"] = "Races on map";

            return View();
        }
    }
}
