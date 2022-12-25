using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class PackageOperations : Operations, IBasicOperations<Package, int, bool>,IPackageByArtist<Package>
    {
        public Package Add(Package cls)
        {
            var pkg=db.Packages.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return pkg;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var package=get(id);
            db.Packages.Remove(package);
            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Package get(int id)
        {
            return db.Packages.Find(id);
        }

        public List<Package> getALL()
        {
            return db.Packages.ToList();
        }

        public List<Package> GetPackageByArtist(int id)
        {
            return (from pkg in db.Packages where pkg.Offered_By==id select pkg).ToList();
        }

        public Package Update(Package cls)
        {
            var package = get(cls.Id);
            if(package != null)
            {
                package.Name = cls.Name;
                package.Offered_By = cls.Offered_By;
                package.Price = cls.Price;
                package.Description= cls.Description;

                db.SaveChanges();

                return package;
            }

            return null;
        }
    }
}
