namespace SM.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product GetProductBy(int productId);
        List<Product> GetAllProducts ();

    }
}
