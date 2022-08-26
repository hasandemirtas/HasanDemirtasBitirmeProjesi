using HasanDemirtasBitirmeProjesi.DataAccess.Concrate;
using HasanDemirtasBitirmeProjesi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasanDemirtasBitirmeProjesi.Business.Concrate
{
    public class TagManager
    {
        private readonly DatabaseContext _db;
        public TagManager()
        {
            _db = new DatabaseContext();
        }

        public List<Tag> ListTags()
        {
            return _db.Tag.ToList();
        }
        public bool AddTag(string name)
        {
            var result = _db.Tag.FirstOrDefault(t => t.Name == name);
            if (result == null)
            {
                Tag tag = new Tag();
                tag.Name = name;
                _db.Add(tag);
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
