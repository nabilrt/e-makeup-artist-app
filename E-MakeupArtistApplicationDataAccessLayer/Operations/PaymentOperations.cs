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
            var payment=db.Payments.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return payment;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var payment = get(id);
            db.Payments.Remove(payment);
            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Payment get(int id)
        {
            return db.Payments.Find(id);
        }

        public List<Payment> getALL()
        {
            return db.Payments.ToList();
        }

        public Payment Update(Payment cls)
        {
            var payment = get(cls.Id);

            if(payment != null)
            {
                payment.Amount = cls.Amount;
                db.SaveChanges();

                return payment;
            }

            return null;
        }
    }
}
