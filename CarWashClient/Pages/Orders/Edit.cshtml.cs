using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarWashClient.Models;
using Newtonsoft.Json;

namespace CarWashClient.Pages.Orders
{
    public class EditModel : PageModel
    {        
        private Order orders;
        
        [BindProperty]
        public Order Order
        {
            get { return orders; }
            set { orders = value; }
        }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:5001/api/orders/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ordersJsonString = await response.Content.ReadAsStringAsync();

                        orders = JsonConvert.DeserializeObject<Order>(ordersJsonString);                        
                    }
                    else { }
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            
            using (var client = new HttpClient())
            {
                var body = JsonConvert.SerializeObject(Order);

                using (var response = await client.PutAsync("https://localhost:5001/api/orders/" + id, new StringContent(body, System.Text.Encoding.Unicode, "application/json")))
                {
                    if (!response.IsSuccessStatusCode)
                    {

                    }
                    else { }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
