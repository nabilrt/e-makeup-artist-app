using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class ArtistOperations : Operations, IBasicOperations<Artist, int, bool>
    {
        public Artist Add(Artist cls)
        {
           var artist=db.Artists.Add(cls);
            db.SaveChanges();

            return artist;
        }

        public bool Delete(int id)
        {
            db.Artists.Remove(get(id));

            return db.SaveChanges() > 0;
        }

        public Artist get(int id)
        {
            return db.Artists.Find(id);
        }

        public List<Artist> getALL()
        {
            return db.Artists.ToList();
        }

        public Artist Update(Artist cls)
        {
            var artist = get(cls.Id);
            artist.Name = cls.Name;
            artist.AreaId = cls.AreaId;
            artist.DOB=cls.DOB;
            artist.Portfolio_Link = cls.Portfolio_Link;
            db.SaveChanges();

            return artist;
            
        }
    }
}
