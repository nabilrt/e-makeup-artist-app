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
    public class OrderDetailServices
    {
        public static List<OrderDetailDTO> getALL()
        {
            var data = DataAccessFactory.OrderDetailDataAccess().getALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(config);
            var orderd = mapper.Map<List<OrderDetailDTO>>(data);

            return orderd;
        }

        public static OrderDetailDTO get(int id)
        {
            var data = DataAccessFactory.OrderDetailDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(config);
            var orderd = mapper.Map<OrderDetailDTO>(data);
            return orderd;
        }

        public static OrderDetailDTO addUser(OrderDetailDTO art)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDetailDTO, OrderDetail>();
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
            });

            var mapper = new Mapper(config);
            var dborder = mapper.Map<OrderDetail>(art);
            var dbord = DataAccessFactory.OrderDetailDataAccess().Add(dbord);

            if (dborder != null)
            {
                return mapper.Map<OrderDetailDTO>(dborder);
            }

            return null;
        }

        public static OrderDetailDTO updateUser(OrderDetailDTO art)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDetailDTO, OrderDetail>();
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<OrderDetail>(art);
            var ret = DataAccessFactory.OrderDetailDataAccess().Update(dbobj);

            return mapper.Map<OrderDetailDTO>(ret);
        }

        public static bool deleteUser(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetailDTO, OrderDetail>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.OrderDetailDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
    }
}
