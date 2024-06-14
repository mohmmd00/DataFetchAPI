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

        private string FetchCategoryName(int id)
        {
            return _repository.GetCategoryNameBy(id);
        }

        public bool CreateNewProduct(CreateProductModel command)
        {
            //validation of create product model
            bool isexist = _repository.IsProductExistsBy(command.Name);
            bool quantityAndPrice = command.Price >= 0 && command.Quantity >= 0;


            if (isexist && !quantityAndPrice)
            {
                return false;
            }
            else
            {
                var newproduct = new Product(command.Name, command.Quantity, command.Price, command.Description, command.ProductCategoryId);

                _repository.CraeteNewProduct(newproduct);
                _repository.SaveChanges();
                return true;
            }

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
                var result = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = FetchCategoryName(productid),
                    Price = product.Price,
                    Quantity = product.Quantity
                };
                return result;
            }


        }

        public List<ProductViewModel> FetchAllProducts()
        {
            var products = _repository.GetAllProducts();
            var result = new List<ProductViewModel>();
            if (products == null)
            {
                return null;
            }
            else
            {
                foreach (var product in products)
                {

                    result.Add(new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Category = FetchCategoryName(product.Id),
                        Price = product.Price,
                        Quantity = product.Quantity

                    });
                }
                return result;
            }

        }

        public List<ProductViewModel> FetchOutOfStockProducts()
        {
            var products = _repository.GetOutOfStockProducts();

            if (products == null)
            {
                return null;
            }
            else
            {
                var result = new List<ProductViewModel>();
                foreach (var product in products)
                {
                    result.Add(new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Category = FetchCategoryName(product.Id),
                        Price = product.Price,
                        Quantity = product.Quantity
                    });
                }
                return result;

            }
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
                foreach (var product in products)
                {
                    result.Add(new ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Category = FetchCategoryName(product.Id),
                        Price = product.Price,
                        Quantity = product.Quantity
                    });
                }
                return result;
            }

        }
    }
}
