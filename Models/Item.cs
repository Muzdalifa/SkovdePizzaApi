using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkovdePizzaApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double Discount { get; set; }
        public string ImagePath { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }
        

    }
}
