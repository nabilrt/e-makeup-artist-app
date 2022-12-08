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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Artist get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Artist> getALL()
        {
            throw new NotImplementedException();
        }

        public Artist Update(Artist cls)
        {
            throw new NotImplementedException();
        }
    }
}
