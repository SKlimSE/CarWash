using CarWashAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashAPI.DAL
{
    public class CWDataContext : DbContext
    {
        public CWDataContext(DbContextOptions<CWDataContext> options) : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
    }
}
