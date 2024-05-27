using SM.Domain.ProductAgg;

namespace SM.Application.Contracts.ProductAgg
{
    public interface IProductApplication
    {
        Product FetchChosenProductBy(int id);
        List<Product> FetchAllProducts();

    }
}
