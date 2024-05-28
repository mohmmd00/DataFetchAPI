using SM.Domain.ProductAgg;

namespace SM.Infrastructure.EFCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public Product GetProductBy(int productId)
        {

            if (productId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId), "ProductId must be a positive integer.");
            }

            Product chosenProduct;
            try
            {
                chosenProduct = _context.Products.Find(productId);
            }
            catch (NullReferenceException)
            {
                return null; 
            }

            return chosenProduct;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public List<Product> GetProductsWithSameCategoryBy(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId), "ProductId must be a positive integer.");
            }
            Product product;
            try
            {
                product = _context.Products.Find(productId);
            }
            catch (NullReferenceException)
            {

                return new List<Product>();
            }
            if (product != null)
            {
                var products = _context.Products
                    .Where(p => p.ProductCategoryId == product.ProductCategoryId && p.Id != productId)
                    .ToList();
                return products;
            }


            return new List<Product>();
        }


    }
}
