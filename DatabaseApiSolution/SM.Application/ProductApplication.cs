﻿using System.Net;
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
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category.Name,
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
            foreach (var product in products)
            {
                result.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category.Name,
                    Price = product.Price,
                    Quantity = product.Quantity

                });
            }
            return result;
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
                        Category = product.Category.Name,
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
                        Category = product.Category.Name,
                        Price = product.Price,
                        Quantity = product.Quantity
                    });
                }
                return result;
            }

        }
    }
}
