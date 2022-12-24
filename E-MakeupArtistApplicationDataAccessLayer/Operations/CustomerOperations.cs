using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class CustomerOperations : Operations, IBasicOperations<Customer, int, bool>,IPremiumMember<Customer>
    {
        public Customer Add(Customer cls)
        {
            db.Customers.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return cls;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var customer=get(id);

            db.Customers.Remove(customer);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Customer get(int id)
        {
            return db.Customers.Find(id);
        }

        public List<Customer> getALL()
        {
            return db.Customers.ToList();
        }

        public bool IsPremiumMember(Customer member)
        {
            var customer =(from cu in db.Customers where cu.Id== member.Id select cu).SingleOrDefault();

            if (customer.Is_Premium == 1)
            {
                return true;
            }

            return false;
        }

        public Customer Update(Customer cls)
        {
            var customer = get(cls.Id);
            if(customer!= null)
            {
                customer.DOB= cls.DOB;
                customer.Name= cls.Name;
                customer.AreaId= cls.AreaId;
                customer.Address= cls.Address;
                customer.Is_Premium= cls.Is_Premium;
                db.SaveChanges();

                return customer;
            }

            return null;
        }
    }
}
