namespace TravelWeb.Models
{
    public class ErrorViewModel
    {
        //properties, model ne mora da postoji za svaki view.
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
