using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbRepository.Service;
using DbRepository.Repository;
using DbRepository.Models;

namespace ProductUpdateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProductController : ControllerBase
    {
        IWriteProduct productService;

        public UpdateProductController(IWriteProduct writeProduct)
        {
            this.productService = writeProduct;
        }

       [HttpPost]
       public ActionResult <Product> Create(Product product)
        {
            return productService.CreateAsync(product).Result;
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Update(string id,[FromBody] Product product)
        {
            return productService.UpdateAsync(id, product).Result;
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            productService.DeleteAsync(id);
        }
    }
}