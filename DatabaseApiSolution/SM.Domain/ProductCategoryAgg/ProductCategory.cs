using SM.Domain.ProductAgg;

namespace SM.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        //primary identifier
        public int Id { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set;}
        public List<Product> Products { get; private set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }
    }
}
