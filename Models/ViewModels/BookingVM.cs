namespace TravelWeb.Models.ViewModels
{
    public class BookingVM
    {
        public IEnumerable<Booking> BookingList { get; set; }
        public double OrderTotal { get; set; }
    }
}
