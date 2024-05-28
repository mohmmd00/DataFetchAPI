using SM.Domain.ProductCategoryAgg;

namespace SM.Application.Contracts.ProductCategoryAgg
{
    public interface IProductCategoryApplication
    {
        List<ProductCategory> FetchAllProductCategories();
    }
}
