using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbRepository.Models;
using DbRepository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductReaderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReaderController : ControllerBase
    {
        IReadProduct productService;

        public ProductReaderController(IReadProduct readProduct)
        {
            this.productService = readProduct;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return productService.GetAsync().Result.ToList();
        }

        [HttpGet]
        [Route("id/{id}")]
        public ActionResult<Product> Get(string id)
        {
            return productService.GetAsync(id).Result;
        }

        [HttpGet]
        [Route("category/{categoryName}")]
        public ActionResult<IEnumerable<Product>> GetByCategory(string categoryName)
        {
            return productService.GetByCategoryAsync(categoryName).Result.ToList();
        }

        [HttpGet]
        [Route("manufacturer/{manufacturerName}")]
        public ActionResult<IEnumerable<Product>> GetByManufacturer(string manufacturerName)
        {
            return productService.GetByManufacturerAsync(manufacturerName).Result.ToList();
        }

        [HttpGet]
        [Route("price/{minPrice}/{maxPrice}")]
        public ActionResult<IEnumerable<Product>> GetByPriceRange(int minPrice, int maxPrice)
        {
            return productService.GetByPriceRangeAsync(minPrice, maxPrice).Result.ToList();
        }
    }
}