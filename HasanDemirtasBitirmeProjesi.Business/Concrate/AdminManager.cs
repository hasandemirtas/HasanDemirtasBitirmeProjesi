using HasanDemirtasBitirmeProjesi.DataAccess.Concrate;
using HasanDemirtasBitirmeProjesi.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasanDemirtasBitirmeProjesi.Business.Concrate
{
    public class AdminManager
    {
        private readonly DatabaseContext _db;
        public AdminManager()
        {
            _db = new DatabaseContext();
        }

        public bool Login(string email, string password)
        {
            var result = _db.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Admin> ListAdmin()
        {
            return _db.Admins.ToList();
        }
    }
}
