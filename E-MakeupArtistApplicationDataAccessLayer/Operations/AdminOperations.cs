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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Admin get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> getALL()
        {
            throw new NotImplementedException();
        }

        public Admin Update(Admin cls)
        {
            throw new NotImplementedException();
        }
    }
}
