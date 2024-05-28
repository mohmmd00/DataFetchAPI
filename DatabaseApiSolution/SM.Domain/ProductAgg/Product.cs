using SM.Domain.ProductCategoryAgg;

namespace SM.Domain.ProductAgg
{
    public class Product
    {   //primary id for product
        public int Id { get; private set; }



        public string ProductName { get; private set; }
        public string ProductDescription { get; private set;}



        public int ProductCategoryId { get; private set;}
        public ProductCategory Category { get; private set; }
    }
}
