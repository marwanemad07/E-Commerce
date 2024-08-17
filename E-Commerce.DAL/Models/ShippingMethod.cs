﻿namespace E_Commerce.DAL.Models
{
    public class ShippingMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}
