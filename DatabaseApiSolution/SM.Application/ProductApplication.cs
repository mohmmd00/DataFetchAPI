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

        public ProductViewModel FetchChosenProductBy(int id)
        {

            var SelectedProduct = _repository.GetProductBy(id);
            var result = new ProductViewModel()
            {
                Name = SelectedProduct.ProductName,
                Description = SelectedProduct.ProductDescription,
                ProductCategoryId = SelectedProduct.ProductCategoryId
            };
            


            return result;
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
    }
}
