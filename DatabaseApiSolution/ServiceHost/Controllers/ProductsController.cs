using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<List<ProductViewModel>> GetAllProducts()
        {
            var Products = _application.FetchAllProducts();
            if (Products == null)
            {
                return NotFound("cant find any products");
            }

            return Products;
        }

        // GET api/<ProductsController>/
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductViewModel> GetSelectedProduct(int id )
        {

            //input cant be negative or zero 
            if (id <= 0)

            {
                return BadRequest("input cant be negative or zero");
            }

            var ChosenProduct = _application.FetchChosenProductBy(id);

            //ProductViewModel cant be null
            if (ChosenProduct == null)
            {
                return NotFound("The product you are looking for was not found");
            }

            return ChosenProduct;
        }

        [HttpGet("{id}/recommendation")]
        public ActionResult<List<ProductViewModel>> GetRecommendationListBy(int id)
        {
            //input cant be negative or zero
            if (id <= 0)
            {
                return BadRequest("Input cant be negative or zero");
            }
            var ChosenProducts = _application.FetchSomeProductsProcessedby(id);
            //ProductViewModel processed list cant be null

            if (ChosenProducts == null)
            {
                return NotFound("cant find any products with similar category");
            }

            return ChosenProducts;
        }

    }
}
