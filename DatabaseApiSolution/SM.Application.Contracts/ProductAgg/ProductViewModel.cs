using SM.Domain.ProductCategoryAgg;

namespace SM.Application.Contracts.ProductAgg
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
