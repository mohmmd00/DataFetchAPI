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

        public void CraeteNewProduct(Product entity)
        {
            _context.Products.Add(entity);
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

        public bool IsProductExistsBy(string name)
        {
            // returns false if there is no product by received name
            bool status = false;
            var selectedproduct = _context.Products.FirstOrDefault(x => x.Name == name);
            if (selectedproduct == null)
            {
                return status;
            }
            else
            {
                status = true;
                return status;
            }
        }

        public bool IsCategoryExistBy(int id)
        {
            bool status = false;
            var chosencategory = _context.ProductCategories.Find(id);
            if (chosencategory == null)
            {
                return status;
            }
            else
            {
                status = true;
                return status;
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
