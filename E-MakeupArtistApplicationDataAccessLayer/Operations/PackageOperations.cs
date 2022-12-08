using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class PackageOperations : Operations, IBasicOperations<Package, int, bool>
    {
        public Package Add(Package cls)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Package get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Package> getALL()
        {
            throw new NotImplementedException();
        }

        public Package Update(Package cls)
        {
            throw new NotImplementedException();
        }
    }
}
