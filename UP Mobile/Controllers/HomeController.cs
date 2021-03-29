using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UP_Mobile.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace UP_Mobile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            _notyf.Custom("Custom Notification - closes in 20 seconds.", 20, "#B600FF", "fa fa-home");
            return View();           
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult UP()
        {
            return View();
        }

        public IActionResult teste()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
