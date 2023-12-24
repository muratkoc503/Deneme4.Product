using Deneme4.Product.Models;

namespace Deneme4.Product.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProduct(int id);
        Task Create(Products product);
        Task<bool> Update(Products product);
        Task<bool> Delete(int id);
    }
}
