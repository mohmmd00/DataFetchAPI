using SM.Domain.ProductAgg;

namespace SM.Application.Contracts.ProductAgg
{
    public interface IProductApplication
    {
        ProductViewModel FetchChosenProductBy(int productid);
        List<ProductViewModel> FetchAllProducts();
        List<ProductViewModel> FetchOutOfStockProducts();
        List<ProductViewModel> FetchSomeProductsProcessedby(int ProductId);
        

    }
}
