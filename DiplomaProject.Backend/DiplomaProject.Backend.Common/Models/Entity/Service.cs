﻿namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TypeService { get; set; }
        public decimal Price { get; set; }

        public Shop Shop { get; set; }
        public List<Order> Orders { get; set; }
        public List<Promotion>? Promotions { get; set; }
    }
}
