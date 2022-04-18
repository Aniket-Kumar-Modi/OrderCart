using Application.CartItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICartItemsService _cartServices;
        public HomeController(ILogger<HomeController> logger, ICartItemsService c)
        {
            _logger = logger;
            _cartServices = c;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy(int orderId)
        {
            var item = _cartServices.GetCartItems(orderId);
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
