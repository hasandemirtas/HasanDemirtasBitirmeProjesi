using HasanDemirtasBitirmeProjesi.DataAccess.Concrate;
using HasanDemirtasBitirmeProjesi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasanDemirtasBitirmeProjesi.Business.Concrate
{
    public class ProductManager
    {
        private readonly DatabaseContext _db;
        public ProductManager()
        {
            _db = new DatabaseContext();
        }

        public List<Product> ListProduct()
        {
            return _db.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();

        }
        public void BuyProduct(int id)
        {
            Product product = _db.Products.FirstOrDefault(p => p.Id == id);
            product.Quantity--;
            _db.SaveChanges();

        }
        public void DeleteProduct(int id)
        {
            Product product = _db.Products.FirstOrDefault(x => x.Id == id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}
