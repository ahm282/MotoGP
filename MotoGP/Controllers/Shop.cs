using Microsoft.AspNetCore.Mvc;

namespace MotoGP.Controllers
{
    public class Shop : Controller
    {

        public IActionResult OrderTicket(int bannerNr) {
            ViewData["BannerPath"] = Info.GetImagePath(bannerNr);
            ViewData["Title"] = "Order Tickets";

            return View();
        }

        public IActionResult ConfirmOrder()
        {
            ViewData["Title"] = "Confirmation";
            ViewData["BannerPath"] = Info.GetImagePath(3);
            ViewData["CurrentDate"] = DateTime.Now.ToString("dd/MM/yyyy");

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
