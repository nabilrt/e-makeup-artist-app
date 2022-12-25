using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class OrderDetailOperations : Operations, IBasicOperations<OrderDetail, int, bool>,IDetailsByOrder<OrderDetail>
    {
        public OrderDetail Add(OrderDetail cls)
        {
            var ordDetails=db.OrderDetails.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return ordDetails;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var orderDetails = get(id);

            db.OrderDetails.Remove(orderDetails);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public OrderDetail get(int id)
        {
            return db.OrderDetails.Find(id);
        }

        public List<OrderDetail> getALL()
        {
            return db.OrderDetails.ToList();
        }

        public List<OrderDetail> GetDetailsByOrder(int id)
        {
            var orderDetails=(from ord in db.OrderDetails where ord.OrderId== id select ord).ToList();

            return orderDetails;
        }

        public OrderDetail Update(OrderDetail cls)
        {
            throw new NotImplementedException();
        }
    }
}
