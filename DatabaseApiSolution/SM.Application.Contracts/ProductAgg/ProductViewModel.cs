﻿using SM.Domain.ProductCategoryAgg;

namespace SM.Application.Contracts.ProductAgg
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
