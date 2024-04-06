namespace TravelWeb.Models.ViewModels
{
    public class BookingVM
    {
        public IEnumerable<Booking> BookingList { get; set; }
        
        public OrderHeader OrderHeader { get; set; }
    }
}
