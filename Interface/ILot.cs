using InventorySmart.Models;

namespace InventorySmart.Interface
{
    public interface ILot
    {
        public Task<List<Lot>> GetAllLots();
        public Task<bool> DeleteLot(int id);
        public Task<Lot> UpdateLot(Lot lot);
        public Task<Lot> CreateLot (Lot lot);
        public Task<List<Lot>> GetLotsByProductId( int id);
        public Task<Lot> GetLotById(int lotId);
    }
}