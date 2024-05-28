using SM.Domain.ProductAgg;

namespace SM.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        //primary id for ProductCategory 
        public int Id { get; private set; }


        public string CategoryName { get; private set; }
        public string CategoryDescription { get; private set;}


        public List<Product> Products { get; private set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }
    }
}
