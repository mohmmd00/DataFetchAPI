﻿using _0_Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

        #region HttpGet
        [HttpGet]
        public ActionResult<List<ProductViewModel>> Products()
        {
            var Products = _application.FetchAllProducts();
            if (Products == null)
            {
                return NotFound("cant find any products");
            }

            return Products;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductViewModel> SelectProductBy(int id)
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
        public ActionResult<List<ProductViewModel>> RecommendationProductsListBy(int id)
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

        [HttpGet("Outofstock")]
        public ActionResult<List<ProductViewModel>> OutOfStockProducts()
        {
            var outofstockproducts = _application.FetchOutOfStockProducts();
            if (outofstockproducts == null)
            {
                return NotFound("there is no out of stock product nor cant found any");
            }
            else
            {
                return outofstockproducts;
            }
        }
        #endregion





        [HttpPost("createproduct")]
        public ActionResult<OperationResult> CreateNewProduct(CreateProductModel command)
        {
            //take a CreateProductModel as a command and process it to add a new record to database through different validation
            var result = _application.CreateNewProduct(command);

            if (result.IsSucceded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
