namespace InventorySmart.Models
{
    public class Lot
    {
        public int idLot { get; set; }
        public int idProduct { get; set; }
        public Product product { get; set; }
        public DateTime startTime { get; set; } 
        public DateTime saleTime { get; set; }
        public int quanty { get; set; }
        public double unitPrice { get; set; }
        public double finalPrice { get; set; }
        public String createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public String lastUpdateBy { get; set; }
        public DateTime lastUpdateDate { get; set; }  
    }
}
