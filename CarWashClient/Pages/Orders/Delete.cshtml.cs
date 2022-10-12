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
    public class DeleteModel : PageModel
    {        

      [BindProperty]
      public Order Order { get; set; }

        //public async Task<IActionResult> OnGetAsync(long? id)
        //{
        //    if (id == null || _context.Order == null)
        //    {
        //        return NotFound();
        //    }



        //    //var order = await _context.Order.FirstOrDefaultAsync(m => m.Id == id);

        //    //if (order == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //else 
        //    //{
        //    //    Order = order;
        //    //}
        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync(long? id)
        {           
            using (var client = new HttpClient())
            {
                var body = Newtonsoft.Json.JsonConvert.SerializeObject(Order);

                using (var response = await client.DeleteAsync("https://localhost:5001/api/orders/" + id))
                {
                    if (!response.IsSuccessStatusCode)
                    {

                    }
                    else { }
                }
            }
            //var order = await _context.Order.FindAsync(id);

            //if (order != null)
            //{
            //    Order = order;
            //    _context.Order.Remove(Order);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
