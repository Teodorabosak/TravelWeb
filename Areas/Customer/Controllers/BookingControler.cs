
using TravelWeb.Models;
using TravelWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using TravelWeb.Repository.IRepository;
using TravelWeb.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe.Checkout;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;

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
                OrderHeader = new()

            };

            foreach (var booking in BookingVM.BookingList)
            {
				booking.Price = GetPriceBasedOnQuantity(booking.NumberOfPeople, booking.Destination.Price);
				
				BookingVM.OrderHeader.OrderTotal += (booking.Destination.Price * booking.NumberOfPeople);
            }

            return View(BookingVM);
        }
		public IActionResult Summary()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			BookingVM = new()
			{
				BookingList = _unit.Booking.GetAll(u => u.ApplicationUserId == userId.Value,
				includeProperties: "Destination"),
				OrderHeader = new()

			};
			BookingVM.OrderHeader.ApplicationName = _unit.ApplicationUser.GetFirstOrDefault(
				u => u.Id == userId.Value);

			BookingVM.OrderHeader.FirstName = BookingVM.OrderHeader.ApplicationName.Name;
			BookingVM.OrderHeader.PhoneNumber = BookingVM.OrderHeader.ApplicationName.PhoneNumber;

			foreach (var booking in BookingVM.BookingList)
			{
				booking.Price = GetPriceBasedOnQuantity(booking.NumberOfPeople, booking.Destination.Price);

				BookingVM.OrderHeader.OrderTotal += (booking.Destination.Price * booking.NumberOfPeople);
			}

			return View(BookingVM);
		}


		[HttpPost]
		[ActionName("Summary")]
		[ValidateAntiForgeryToken]
		public IActionResult SummaryPOST()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			BookingVM.BookingList = _unit.Booking.GetAll(u => u.ApplicationUserId == userId.Value,
				includeProperties: "Destination");

			BookingVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
			BookingVM.OrderHeader.OrderDate = System.DateTime.Now;
			BookingVM.OrderHeader.ApplicationUserId = userId.Value;



			foreach (var booking in BookingVM.BookingList)
			{
				booking.Price = GetPriceBasedOnQuantity(booking.NumberOfPeople, booking.Destination.Price);

				BookingVM.OrderHeader.OrderTotal += (booking.Destination.Price * booking.NumberOfPeople);
			}



			_unit.OrderHeader.Add(BookingVM.OrderHeader);
			_unit.Save();




			foreach (var booking in BookingVM.BookingList)
			{
				OrderDetail orderDetail = new()
				{
					DestinationId = booking.DestinationId,
					OrderHeaderId = BookingVM.OrderHeader.Id,
					Price = booking.Price,
					NumberOfPeople = booking.NumberOfPeople
				};
				_unit.OrderDetail.Add(orderDetail);
				_unit.Save();
			}
			//stripe settings 
			var domain = "https://localhost:7048/";
			var options = new SessionCreateOptions
			{
				PaymentMethodTypes = new List<string>
				{
				  "card",
				},
				SuccessUrl = domain + $"customer/booking/OrderConfirmation?id={BookingVM.OrderHeader.Id}",

				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",

				CancelUrl = domain + $"customer/booking/index",
			};

			foreach (var item in BookingVM.BookingList)
			{

				var sessionLineItem = new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = (long)(item.Price)*100,
						Currency = "EUR",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = item.Destination.Name,

						}

					},
					Quantity = item.NumberOfPeople,
				};
				options.LineItems.Add(sessionLineItem);

			}

			var service = new SessionService();
			Session session = service.Create(options);

			_unit.OrderHeader.UpdateStripePaymentID(BookingVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
			_unit.Save();
			Response.Headers.Add("Location", session.Url);

			return new StatusCodeResult(303);


		}
		public IActionResult OrderConfirmation(int id)
		{
			OrderHeader orderHeader = _unit.OrderHeader.GetFirstOrDefault(u => u.Id == id);

			var service = new SessionService();
			Session session = service.Get(orderHeader.SessionId);
			//check the stripe status
			if (session.PaymentStatus.ToLower() == "paid")
			{
				_unit.OrderHeader.UpdateStatus(id, SD.PaymentStatusApproved);
				_unit.Save();
			}
			List<Booking> bookings = _unit.Booking.GetAll(u => u.ApplicationUserId ==
			orderHeader.ApplicationUserId).ToList();
			_unit.Booking.DeleteRange(bookings);
			_unit.Save();
			return View(id);
		}

		public IActionResult Plus(int bookingId)
        {
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
		private double GetPriceBasedOnQuantity(double quantity, double price)
		{
			return price;

		}
		


	}
}