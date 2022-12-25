using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class OrderOperations : Operations, IBasicOperations<Order, int, bool>,IOrderByUser<Order>
    {
        public Order Add(Order cls)
        {
            var order=db.Orders.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return order;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var order=get(id);

            db.Orders.Remove(order);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Order get(int id)
        {
            return db.Orders.Find(id);
        }

        public List<Order> getALL()
        {
            return db.Orders.ToList();
        }

        public List<Order> GetOrderByArtist(int id)
        {
            var orders=(from ord in db.Orders where ord.ArtistId==id select ord).ToList();

            return orders;
        }

        public List<Order> GetOrderByCustomer(int id)
        {
            var orders=(from ord in db.Orders where ord.CustomerId==id select ord).ToList();    

            return orders;
        }

        public Order Update(Order cls)
        {
            var order = get(cls.Id);
            if(order!= null)
            {
                order.Status = cls.Status;
                db.SaveChanges();

                return order;
            }

            return null;




        }
    }
}
