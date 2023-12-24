namespace InventorySmart.Models
{
    public class SubCategory
    {
        public int idSubcategory {set;get;}
        public int idCategory { get; set; }
        public int idSize { get; set; }
        public ProductSize productSize { get; set; }   
        public Category category { get; set; }
        public String name { get; set; }
        public String description { get; set; }


    }
}
