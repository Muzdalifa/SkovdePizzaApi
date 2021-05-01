using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkovdePizzaApi.Models;

    public class SkovdePizzaApiContext : DbContext
    {
        public SkovdePizzaApiContext (DbContextOptions<SkovdePizzaApiContext> options)
            : base(options)
        {
        }

        public DbSet<SkovdePizzaApi.Models.Item> Items { get; set; }
    }
