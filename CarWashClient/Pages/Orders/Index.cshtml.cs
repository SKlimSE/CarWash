using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarWashClient.Data;
using CarWashClient.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections;

namespace CarWashClient.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly CarWashClientContext _context;

        public IndexModel(CarWashClientContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {            
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:5001/api/orders"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ordersJsonString = await response.Content.ReadAsStringAsync();

                        Order = new List<Order>(JsonConvert.DeserializeObject<Order[]>(ordersJsonString)).ToList();
                    }
                    else { }
                }
            }
        }
    }
}
