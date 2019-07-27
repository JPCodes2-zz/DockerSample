using DbRepository.Models;
using DbRepository.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbRepository.Repository
{
    public class ProductRepository : IReadProduct, IWriteProduct
    {
        ProductDbContext productDbx;

        public ProductRepository()
        {
            this.productDbx = new ProductDbContext();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var res= await productDbx.Products.AddAsync(product);

            await productDbx.SaveChangesAsync();

            return res.Entity;
        }

        public async Task<Product> UpdateAsync(string id, Product product)
        {
            var res = await productDbx.Products.FindAsync(id);

            if (res != null)
            {
                res.Manufacturer = product.Manufacturer;
                res.Price = product.Price;
                res.ProductName = product.ProductName;

                await productDbx.SaveChangesAsync();
            }
            return res;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var res = await productDbx.Products.FindAsync(id);

            if(res!=null)
            {
                productDbx.Remove(res);
                await productDbx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await productDbx.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(string id)
        {
            return await productDbx.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
        {
           return await productDbx.Products.Where(p => p.CategoryName == categoryName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByManufacturerAsync(string manufacturerName)
        {
            return await productDbx.Products.Where(p => p.Manufacturer == manufacturerName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByPriceRangeAsync(int minPrice, int maxPrice)
        {
            return await productDbx.Products.Where(p => p.Price >= minPrice && p.Price<=maxPrice).ToListAsync();
        }

       
    }
}
