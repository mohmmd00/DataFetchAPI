namespace SM.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product GetProductBy(int productId);
        List<Product> GetAllProducts ();
        List<Product> GetOutOfStockProducts();
        List<Product> GetProductsWithSameCategoryBy(int productid);
    }
}
