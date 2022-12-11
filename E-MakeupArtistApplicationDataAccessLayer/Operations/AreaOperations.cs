using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class AreaOperations : Operations, IBasicOperations<Area, int, bool>
    {
        public Area Add(Area cls)
        {
            var area=db.Areas.Add(cls);

            db.SaveChanges();

            return area;
        }

        public bool Delete(int id)
        {
            db.Areas.Remove(get(id));

            return db.SaveChanges() > 0;
        }

        public Area get(int id)
        {
           return db.Areas.Find(id);
        }

        public List<Area> getALL()
        {
            return db.Areas.ToList();
        }

        public Area Update(Area cls)
        {
            var area = get(cls.Id);

            area.Name=cls.Name;

            db.SaveChanges();

            return area;
        }
    }
}
