using System.ComponentModel.DataAnnotations;

namespace CarWashClient.Models
{    
    public class Order
    {
        public long Id { get; set; }
        public string NameClient { get; set; }
        public string? PhoneClient { get; set; }
        public string? NameService { get; set; }        
        public byte Amount { get; set; }
        public decimal Price { get; set; }        
        public DateTime DateOfServiceProvision { get; set; }
    }
}
