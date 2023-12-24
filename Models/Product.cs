namespace InventorySmart.Models
{
    public class Product
    {
        public int idProduct { get; set; }
        public int idInventory { get; set; }
        public int idLot { get; set; }  
        public int idCategory { get; set; } 
        public int idSubCategory { get; set; }  
        public String name { get; set; }
        public string description { get; set; }
        public double finalPrice { get; set; }
        public String createBy { get; set; }
        public DateTime createdDate { get; set; }
        public String lastUpdatedBy { get; set; }
        public DateTime lastUpdatedDate { get; set; }
    }
}
