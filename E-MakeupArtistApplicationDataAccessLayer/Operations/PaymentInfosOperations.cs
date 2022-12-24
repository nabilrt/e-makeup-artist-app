using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class PaymentInfosOperations : Operations, IBasicOperations<PaymentInfo, int, bool>
    {
        public PaymentInfo Add(PaymentInfo cls)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentInfo get(int id)
        {
            return db.PaymentInfos.Find(id);
        }

        public List<PaymentInfo> getALL()
        {
            return db.PaymentInfos.ToList();
        }

        public PaymentInfo Update(PaymentInfo cls)
        {
            var paymentInfo = get(cls.Id);

            if (paymentInfo != null)
            {
                paymentInfo.Price = cls.Price;
                paymentInfo.Discount = cls.Discount;

                db.SaveChanges();

                return paymentInfo;
            }

            return null;
        }
    }
}
