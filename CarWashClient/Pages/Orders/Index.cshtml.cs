using Microsoft.AspNetCore.Mvc.RazorPages;
using CarWashClient.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CarWashClient.Pages.Orders
{
    public class IndexModel : PageModel
    {       
        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Order
        {
            get { return orders; }
            set { orders = value; }
        }

        public async Task OnGetAsync()
        {            
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:5001/api/orders"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ordersJsonString = await response.Content.ReadAsStringAsync();

                        orders = new ObservableCollection<Order>(JsonConvert.DeserializeObject<Order[]>(ordersJsonString));
                    }
                    else { }
                }
            }
        }
    }
}
