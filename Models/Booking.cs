using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWeb.Models
{
    public class Booking
    {
        
        public int Id { get; set; }

        public int DestinationId { get; set; }
        [ForeignKey("DestinationId")]
        [ValidateNever]
        public Destination Destination { get; set; }

        public int NumberOfPeople { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }


		[NotMapped]
		public double Price { get; set; }

	}
}
