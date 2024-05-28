using SM.Domain.ProductAgg;

namespace SM.Application.Contracts.ProductAgg
{
    public interface IProductApplication
    {
        ProductViewModel FetchChosenProductBy(int ProductId);
        List<ProductViewModel> FetchAllProducts();
        List<ProductViewModel> FetchSomeProductsFilteredby(int ProductId);

    }
}
