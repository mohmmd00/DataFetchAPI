namespace SM.Application.Contracts.ProductAgg
{
    public interface IProductApplication
    {
        bool CreateNewProduct(CreateProductModel command);
        ProductViewModel FetchChosenProductBy(int productid);
        List<ProductViewModel> FetchAllProducts();
        List<ProductViewModel> FetchOutOfStockProducts();
        List<ProductViewModel> FetchSomeProductsProcessedby(int ProductId);
    }
}
