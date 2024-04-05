using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using TravelWeb.Migrations;
using TravelWeb.Models;
using TravelWeb.Models.ViewModels;
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
            Booking booking = new()
            {

                Destination = _unit.Destination.Get(u => u.Id == id, includeProperties: "Category"),
                NumberOfPeople = 1,
                DestinationId = id

            };

            return View(booking);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(Booking booking)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            booking.ApplicationUserId = userId;

            Booking booDb = _unit.Booking.Get(u => u.ApplicationUserId == userId &&
            u.DestinationId == booking.DestinationId);
            
            if(booDb != null)
            {
                booDb.NumberOfPeople += booking.NumberOfPeople;
                //_unit.Booking.Update(booDb);

            } else
            {

                _unit.Booking.Add(booking);
            }
            TempData["success"] = "Uspesno ste rezervisali putovanje";

            _unit.Save();

            
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
