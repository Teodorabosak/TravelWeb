using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWeb.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Destinacija")]
        [Required]
        public string Name { get; set; }

        [Display(Name ="Opis")]
        [Required]
        public string Description { get; set; }

        
        [Required]
        public string Hotel { get; set; }

        [Display(Name = "Cena")]
        [Required]
        public double Price { get; set; }
        
        [Display(Name = "Datum polaska")]
        [Required]
        public DateTime Date1 { get; set; }

        [Display(Name = "Datum povratka")]
        [Required]
        public DateTime Date2 { get; set; }

        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }




    }
}
