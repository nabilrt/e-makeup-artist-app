using AutoMapper;
using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
using E_MakeupArtistApplicationDataAccessLayer;
using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.Services
{
    public class PaymentServices
    {
        public static List<PaymentDTO> GetPayment()
        {
            var data = DataAccessFactory.PaymentDataAccess().getALL();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>();
            });

            var mapper = new Mapper(config);
            var payment = mapper.Map<List<PaymentDTO>>(data);

            return payment;
        }

        public static PaymentDTO GetPayment(int id)
        {
            var data = DataAccessFactory.PaymentDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>();
            });

            var mapper = new Mapper(config);
            var payment = mapper.Map<PaymentDTO>(data);

            return payment;
        }

        public static PaymentDTO UpdatePayment(PaymentDTO payment)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentDTO, Payment>();
                cfg.CreateMap<Payment, PaymentDTO>();
            });

            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Payment>(payment);
            var ret = DataAccessFactory.PaymentDataAccess().Update(dbobj);

            return mapper.Map<PaymentDTO>(ret);
        }
      

        public static bool deletePayment(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, Payment>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.PaymentDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }


    }
}
