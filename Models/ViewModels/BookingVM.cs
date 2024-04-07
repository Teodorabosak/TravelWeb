using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TravelWeb.Models.ViewModels
{
    public class BookingVM
    {
        [ValidateNever]
        public IEnumerable<Booking> BookingList { get; set; }
        
        public OrderHeader OrderHeader { get; set; }
    }
}
