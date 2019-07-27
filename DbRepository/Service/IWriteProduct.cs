using DbRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Service
{
    public interface IWriteProduct
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(string id, Product product);
        Task<bool> DeleteAsync(string id);
    }
}
