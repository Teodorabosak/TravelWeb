
using TravelWeb.Models;
using TravelWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using TravelWeb.Repository.IRepository;

namespace TravelWebWeb.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize]
    
    public class BookingController : Controller
    {
        private readonly IUnit _unit;
        public BookingVM BookingVM { get; set; }
        public BookingController(IUnit unit)
        {
            _unit = unit;

        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            BookingVM = new()
            {
               BookingList = _unit.Booking.GetAll(u => u.ApplicationUserId == userId,
                 includeProperties: "Destination"),

            };

            foreach (var booking in BookingVM.BookingList)
            {
                double price = booking.Destination.Price;
                BookingVM.OrderTotal += (booking.Destination.Price * booking.NumberOfPeople);
            }

            return View(BookingVM);
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            BookingVM = new()
            {
                BookingList = _unit.Booking.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "Destination"),

            };

            foreach (var booking in BookingVM.BookingList)
            {
                double price = booking.Destination.Price;
                BookingVM.OrderTotal += (booking.Destination.Price * booking.NumberOfPeople);
            }

            return View(BookingVM);
        }



    }
}