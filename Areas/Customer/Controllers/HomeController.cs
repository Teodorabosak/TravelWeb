using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TravelWeb.Models;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnit _unit;
        
        public HomeController(ILogger<HomeController> logger,IUnit unit)
        {
            _logger = logger;
            _unit = unit;
        }

        //Action methods
        public IActionResult Index()
        {
            IEnumerable<Destination> destinations = _unit.Destination.GetAll(includeProperties: "Category");
            return View(destinations);
            //vraca view Index-na osn naziva metode, ako nismo naveli u zagradi
        }

        public IActionResult Details(int id)
        {
            Destination destination = _unit.Destination.Get(u => u.Id == id, includeProperties: "Category");
            return View(destination);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
