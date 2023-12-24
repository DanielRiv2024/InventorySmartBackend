using InventorySmart.Models;

namespace InventorySmart.Interface
{
    public interface ILot
    {
        public Task<List<Lot>> GetAllLots();

    }
}
