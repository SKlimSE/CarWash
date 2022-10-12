using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarWashClient.Models;
using Newtonsoft.Json;

namespace CarWashClient.Pages.Orders
{
    public class CreateModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)                
            {
                return Page();
            }

            Order.DateOfServiceProvision = DateTime.Now;

            using (var client = new HttpClient())
            {
                var body = JsonConvert.SerializeObject(Order);

                using (var response = await client.PostAsync("https://localhost:5001/api/orders", new StringContent(body, System.Text.Encoding.Unicode, "application/json")))
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
