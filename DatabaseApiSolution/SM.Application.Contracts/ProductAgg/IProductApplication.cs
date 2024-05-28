using SM.Domain.ProductAgg;

namespace SM.Application.Contracts.ProductAgg
{
    public interface IProductApplication
    {
        ProductViewModel FetchChosenProductBy(int id);
        List<ProductViewModel> FetchAllProducts();

    }
}
