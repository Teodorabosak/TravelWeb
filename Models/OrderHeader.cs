using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWeb.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationName { get; set; }

        public DateTime OrderDate { get; set; }

        public double OrderTotal {  get; set; }

        public string? SessionId { get; set; }

        
        public string? PaymentStatus {  get; set; }
        
        public string? PaymentIntentId { get; set; }
        
        public string? PhoneNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        

        


    }
}
