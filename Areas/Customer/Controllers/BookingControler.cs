
using TravelWeb.Models;
using TravelWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using TravelWeb.Repository.IRepository;
using TravelWeb.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace TravelWebWeb.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize]
    
    public class BookingController : Controller
    {
        private readonly IUnit _unit;
        private readonly IEmailSender _emailSender;
        [BindProperty]
        public BookingVM BookingVM { get; set; }
        public BookingController(IUnit unit, IEmailSender emailSender)
        {
            _unit = unit;
            _emailSender = emailSender;

        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            BookingVM = new()
            {
               BookingList = _unit.Booking.GetAll(u => u.ApplicationUserId == userId.Value,
                 includeProperties: "Destination"),
               OrderHeader= new()

            };

            foreach (var booking in BookingVM.BookingList)
            {
                double price = booking.Destination.Price;
                BookingVM.OrderHeader.OrderTotal += (booking.Destination.Price * booking.NumberOfPeople);
            }

            return View(BookingVM);
        }
        public IActionResult Plus(int bookingId) {
            var booDb = _unit.Booking.GetFirstOrDefault(u => u.Id == bookingId);
            booDb.NumberOfPeople += 1;
            _unit.Booking.Update(booDb);
            _unit.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int bookingId)
        {
            var booDb = _unit.Booking.GetFirstOrDefault(u => u.Id == bookingId);
            if (booDb.NumberOfPeople <= 1)
            {
                //remove that from booking

                _unit.Booking.Delete(booDb);
               
            }
            else
            {
                booDb.NumberOfPeople -= 1;
                _unit.Booking.Update(booDb);
            }

            _unit.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int bookingId)
        {
            var booDb = _unit.Booking.GetFirstOrDefault(u => u.Id == bookingId);

            _unit.Booking.Delete(booDb);

          
            _unit.Save();
            return RedirectToAction(nameof(Index));
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
                BookingVM.OrderHeader.OrderTotal += (booking.Destination.Price * booking.NumberOfPeople);
            }

            return View(BookingVM);
        }



    }
}