using InventorySmart.Models;

namespace InventorySmart.Interface
{
    public interface IProduct
    {
        public Task<List<Product>> GetAllProducts();

    }
}
