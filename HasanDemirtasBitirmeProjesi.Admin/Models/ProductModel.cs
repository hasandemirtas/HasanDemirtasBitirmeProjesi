using HasanDemirtasBitirmeProjesi.Entity.Entities;

namespace HasanDemirtasBitirmeProjesi.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
