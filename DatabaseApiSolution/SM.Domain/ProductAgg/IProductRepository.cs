namespace SM.Domain.ProductAgg
{
    public interface IProductRepository
    {

        void CraeteNewProduct(Product entity);

        Product GetProductBy(int productId);
        List<Product> GetAllProducts ();
        List<Product> GetOutOfStockProducts();
        List<Product> GetProductsWithSameCategoryBy(int productid);
        string GetCategoryNameBy(int productid);
        bool IsProductExistsBy(string name);
        void SaveChanges();
    }
}
