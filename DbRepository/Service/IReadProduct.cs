using DbRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Service
{
    public interface IReadProduct
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> GetAsync(string id);

        Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName);
        Task<IEnumerable<Product>> GetByPriceRangeAsync(int minPrice, int maxPrice);
        Task<IEnumerable<Product>> GetByManufacturerAsync(string manufacturerName);

    }
}
