using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkovdePizzaApi.Models
{
    public class SkovdePizzaApiContext : DbContext
    {
        public SkovdePizzaApiContext(DbContextOptions<SkovdePizzaApiContext> options) : base(options)
        {
        }

        public DbSet<Item> Items {get; set;}
    }
}
