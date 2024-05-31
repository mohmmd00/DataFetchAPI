using System.Net;
using SM.Application.Contracts.ProductAgg;
using SM.Domain.ProductAgg;

namespace SM.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _repository;

        public ProductApplication(IProductRepository repository)
        {
            _repository = repository;
        }

        public ProductViewModel FetchChosenProductBy(int productid)
        {
            var product = _repository.GetProductBy(productid);
            if (product == null)
            {
                return null;
            }
            else
            {
                var result = new ProductViewModel()
                {
                    Name = product.ProductName,
                    Description = product.ProductDescription,
                    ProductCategoryId = product.ProductCategoryId
                };
                return result;
            }


        }

        public List<ProductViewModel> FetchAllProducts()
        {
            var Products = _repository.GetAllProducts();
            var result = new List<ProductViewModel>();
            foreach (var Product in Products)
            {
                result.Add(new ProductViewModel
                {
                    Name = Product.ProductName,
                    Description = Product.ProductDescription,
                    ProductCategoryId = Product.ProductCategoryId
                });
            }
            return result;
        }

        public List<ProductViewModel> FetchSomeProductsProcessedby(int ProductId)
        {
            var products = _repository.GetProductsWithSameCategoryBy(ProductId);

            if (products == null)
            {
                return null;
            }
            else
            {
                var result = new List<ProductViewModel>();
                foreach (var Product in products)
                {
                    result.Add(new ProductViewModel
                    {
                        Name = Product.ProductName,
                        Description = Product.ProductDescription,
                        ProductCategoryId = Product.ProductCategoryId

                    });
                }
                return result;
            }

        }
    }
}
