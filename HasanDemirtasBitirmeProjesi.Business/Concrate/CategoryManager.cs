using HasanDemirtasBitirmeProjesi.DataAccess.Concrate;
using HasanDemirtasBitirmeProjesi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasanDemirtasBitirmeProjesi.Business.Concrate
{
    public class CategoryManager
    {
        private readonly DatabaseContext _db;
        public CategoryManager()
        {
            _db = new DatabaseContext();
        }

        public List<Category> ListCategories()
        {
            return _db.Categories.ToList();
        }
        public bool AddCategory(string name)
        {
            var result = _db.Categories.FirstOrDefault(c => c.Name == name);
            if(result == null)
            {
                Category category = new Category();
                category.Name = name;
                _db.Add(category);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
