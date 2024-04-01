using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelWeb.Models;

namespace TravelWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Action methods
        public IActionResult Index()
        {
            return View();
            //vraca view Index-na osn naziva metode, ako nismo naveli u zagradi
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
