using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var ChosenProduct = _context.Products.Find(productId);

            if (ChosenProduct != null)
            {
                return ChosenProduct;
            }

            return null;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
