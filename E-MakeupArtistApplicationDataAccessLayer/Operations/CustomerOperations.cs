using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class CustomerOperations : Operations, IBasicOperations<Customer, int, bool>
    {
        public Customer Add(Customer cls)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> getALL()
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer cls)
        {
            throw new NotImplementedException();
        }
    }
}
