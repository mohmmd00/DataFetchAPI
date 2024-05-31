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
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductBy(int productId)
        {
            var SelectedProduct = _context.Products.Find(productId);

            if (SelectedProduct != null)
            {
                return SelectedProduct;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductsWithSameCategoryBy(int productid)
        {
            var SelectedProduct = _context.Products.Find(productid);

            if (SelectedProduct != null)
            {
                var products = _context.Products
                    .Where(p => p.ProductCategoryId == SelectedProduct.ProductCategoryId && p.Id != productid)
                    .ToList();
                return products;
            }

            return null;
        }


    }
}
