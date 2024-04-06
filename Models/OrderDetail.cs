using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWeb.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int DestinationId { get; set; }
        [ForeignKey("DestinationId")]
        [ValidateNever]
        public Destination Destination { get; set; }

        public int NumberOfPeople { get; set; }

        public double Price {  get; set; }
    }
}
