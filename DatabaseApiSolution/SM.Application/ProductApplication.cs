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

        public Product FetchChosenProductBy(int id)
        {

            var SelectedProduct = _repository.GetProductBy(id);
            if (SelectedProduct != null)
            {
                return SelectedProduct;
            }

            return null;
        }

        public List<Product> FetchAllProducts()
        {
            return _repository.GetAllProducts();
        }
    }
}
