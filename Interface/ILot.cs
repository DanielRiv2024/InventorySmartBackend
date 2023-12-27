using InventorySmart.Models;

namespace InventorySmart.Interface
{
    public interface ILot
    {
        public Task<List<Lot>> GetAllLots();
        public Task<Lot> GetLotById(int id);
        public Boolean DeleteLot(int id);
        public Task<Lot> UpdateLot(Lot lot);
        public Task<Lot> CreateLot (Lot lot);
    }
}
