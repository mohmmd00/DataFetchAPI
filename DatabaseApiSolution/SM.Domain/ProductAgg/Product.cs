using SM.Domain.ProductCategoryAgg;

namespace SM.Domain.ProductAgg
{
    public class Product
    {   //primary identifier
        public int Id { get; private set; }

        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set;}
        public int ProductCategoryId { get; private set;}
        public ProductCategory Category { get; private set; }

        public Product(string name, int quantity, double price, string description, int productCategoryId)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            Description = description;
            ProductCategoryId = productCategoryId;
        }
    }
}
