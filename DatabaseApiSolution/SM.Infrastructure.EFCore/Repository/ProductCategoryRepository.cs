using SM.Domain.ProductCategoryAgg;

namespace SM.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {


        private readonly StoreContext _context;

        public ProductCategoryRepository(StoreContext context)
        {
            _context = context;
        }

        public List<ProductCategory> GetAllProductCategories()
        {
            return _context.ProductCategories.ToList();
        }
    }
}
