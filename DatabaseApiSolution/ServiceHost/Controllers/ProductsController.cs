using Microsoft.AspNetCore.Mvc;
using SM.Application.Contracts.ProductAgg;


namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplication _application;

        public ProductsController(IProductApplication application)
        {
            _application = application;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public List<ProductViewModel> GetAllProducts()
        {
            var Products =_application.FetchAllProducts();

            return Products;
        }

        // GET api/<ProductsController>/
        [HttpGet("{id}")]
        public ProductViewModel GetASingleProduct(int id)
        {
            var ChosenProduct = _application.FetchChosenProductBy(id);

            return ChosenProduct;
        }

        [HttpGet("{id}/recommendation")]
        public List<ProductViewModel> GetRecommendationListBy(int id)
        {
            var ChosenProducts =  _application.FetchSomeProductsFilteredby(id);
           
            return ChosenProducts;
        }

    }
}
