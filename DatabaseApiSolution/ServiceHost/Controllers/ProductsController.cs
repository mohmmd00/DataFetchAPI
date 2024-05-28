﻿using Microsoft.AspNetCore.Mvc;
using SM.Application.Contracts.ProductAgg;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            return _application.FetchAllProducts();
        }

        // GET api/<ProductsController>/
        [HttpGet("{id}")]
        public ProductViewModel GetASingleProduct(int id)
        {
            var ChosenProduct = _application.FetchChosenProductBy(id);

            return ChosenProduct;
        }
    }
}