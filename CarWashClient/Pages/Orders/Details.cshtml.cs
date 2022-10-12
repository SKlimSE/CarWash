using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarWashClient.Models;

namespace CarWashClient.Pages.Orders
{
    public class DetailsModel : PageModel
    {

      public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            
            return Page();
        }
    }
}
