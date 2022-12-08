using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class OrderOperations : Operations, IBasicOperations<Order, int, bool>
    {
        public Order Add(Order cls)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> getALL()
        {
            throw new NotImplementedException();
        }

        public Order Update(Order cls)
        {
            throw new NotImplementedException();
        }
    }
}
