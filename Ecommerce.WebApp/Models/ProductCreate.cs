﻿using Ecommerce.Models.EntityModels;

namespace Ecommerce.WebApp.Models
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
    }
}
