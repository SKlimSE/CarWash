using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarWashClient.Models;
using Newtonsoft.Json;

namespace CarWashClient.Pages.Orders
{
    public class EditModel : PageModel
    {
        
        [BindProperty]
        public Order Order { get; set; } = default!;
       
        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var client = new HttpClient())
            {
                var body = JsonConvert.SerializeObject(Order);

                using (var response = await client.PutAsync("https://localhost:5001/api/orders" + id, new StringContent(body, System.Text.Encoding.Unicode, "application/json")))
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
