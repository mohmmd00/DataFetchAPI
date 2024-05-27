using SM.Application.Contracts.ProductCategoryAgg;
using SM.Domain.ProductCategoryAgg;

namespace SM.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryApplication(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public List<ProductCategory> FetchAllProductCategories()
        {
            return _repository.GetAllProductCategories();
        }
    }
}
