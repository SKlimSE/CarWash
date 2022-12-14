using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWashAPI.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string NameClient { get; set; }
        [Required]
        public string PhoneClient { get; set; }
        [Required]
        public string? NameService { get; set; }    
        [Required]
        public byte Amount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime DateOfServiceProvision { get; set; }        
    }    
}
