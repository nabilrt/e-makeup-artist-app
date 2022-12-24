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
    public class PaymentInfoServices
    {
        public static List<PaymentInfoDTO> GetPaymentInfos()
        {
            var data=DataAccessFactory.PaymentInfoDataAccess().getALL();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentInfo, PaymentInfoDTO>();
            });

            var mapper = new Mapper(config);
            var paymentinfo=mapper.Map<List<PaymentInfoDTO>>(data);

            return paymentinfo;
        }

        public static PaymentInfoDTO GetPaymentInfo(int id)
        {
            var data=DataAccessFactory.PaymentInfoDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentInfo, PaymentInfoDTO>();
            });

            var mapper = new Mapper(config);
            var payment=mapper.Map<PaymentInfoDTO>(data);

            return payment;
        }

        public static PaymentInfoDTO UpdatePaymentInfo(PaymentInfoDTO paymentInfo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentInfoDTO, PaymentInfo>();
                cfg.CreateMap<PaymentInfo,PaymentInfoDTO>();
            });

            var mapper = new Mapper(config);
            var dbobj = mapper.Map<PaymentInfo>(paymentInfo);
            var ret=DataAccessFactory.PaymentInfoDataAccess().Update(dbobj);

            return mapper.Map<PaymentInfoDTO>(ret);
        }
    }
}
