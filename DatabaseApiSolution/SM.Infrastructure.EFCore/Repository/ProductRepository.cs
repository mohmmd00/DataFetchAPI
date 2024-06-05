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

        public List<Product> GetOutOfStockProducts()
        {
            var outofstock = _context.Products.Where(x=>x.Quantity == 0).ToList();

            if (outofstock == null)
            {
                return null;
            }
            else
            {
                return outofstock;
            }
        }

        public Product GetProductBy(int productId)
        {
            var selectedproduct = _context.Products.Find(productId);

            if (selectedproduct == null)
            {
                return null;
            }
            else
            {
                return selectedproduct;
            }
        }

        public List<Product> GetProductsWithSameCategoryBy(int productid)
        {
            var selectedproduct = _context.Products.Find(productid);

            if (selectedproduct == null)
            {
                return null;
            }
            else
            {
                var products = _context.Products
                    .Where(p => p.ProductCategoryId == selectedproduct.ProductCategoryId && p.Id != productid)
                    .ToList();

                return products;
            }
        }
        public string GetCategoryNameBy(int productid)
        {
            var SelectedProduct = _context.Products.Find(productid);

            var categoryname = _context.ProductCategories.FirstOrDefault(X => X.Id == SelectedProduct.ProductCategoryId).Name;

            if (SelectedProduct == null)
            {
                return null;
            }
            else
            {
                return categoryname;
            }
        }
    }
}
