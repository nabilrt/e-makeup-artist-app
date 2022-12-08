using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class PaymentOperations : Operations, IBasicOperations<Payment, int, bool>
    {
        public Payment Add(Payment cls)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Payment get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> getALL()
        {
            throw new NotImplementedException();
        }

        public Payment Update(Payment cls)
        {
            throw new NotImplementedException();
        }
    }
}
