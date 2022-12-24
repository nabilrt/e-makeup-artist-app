using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class AdminOperations : Operations, IBasicOperations<Admin, int, bool>
    {
        public Admin Add(Admin cls)
        {
            db.Admins.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return cls;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var admin= db.Admins.Find(id);

            db.Admins.Remove(admin);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Admin get(int id)
        {
            return db.Admins.Find(id);
        }

        public List<Admin> getALL()
        {
            throw new NotImplementedException();
        }

        public Admin Update(Admin cls)
        {
            var admin = get(cls.Id);
            if (admin != null)
            {
                admin.Name = cls.Name;
                admin.DOB = cls.DOB;

                db.SaveChanges();

                return admin;
            }

            return null;
        }
    }
}
