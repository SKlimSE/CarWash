using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarWashClient.Models;
using System.Collections.ObjectModel;

namespace CarWashClient.Data
{
    public class CarWashClientContext : DbContext
    {
        public CarWashClientContext (DbContextOptions<CarWashClientContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; } = default!;
    }
}
