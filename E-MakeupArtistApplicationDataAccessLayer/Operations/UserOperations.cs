using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class UserOperations : Operations, IBasicOperations<User, int, bool>
    {
        public User Add(User cls)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> getALL()
        {
            throw new NotImplementedException();
        }

        public User Update(User cls)
        {
            throw new NotImplementedException();
        }
    }
}
