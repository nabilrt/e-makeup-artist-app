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
    public class OrderServices
    {
        public static List<OrderDTO> GetOrder()
        {
            var data = DataAccessFactory.OrderDataAccess().getALL();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });

            var mapper = new Mapper(config);
            var order = mapper.Map<List<OrderDTO>>(data);

            return order;
        }

        public static List<OrderDTO> GetOrderByArtist(int id)
        {
            var data = DataAccessFactory.GetOrderByUser().GetOrderByArtist(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });

            var mapper = new Mapper(config);
            var orders = mapper.Map<List<OrderDTO>>(data);

            return orders;
        }

        public static List<OrderDTO> GetOrderByCustomer(int id)
        {
            var data = DataAccessFactory.GetOrderByUser().GetOrderByCustomer(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });

            var mapper = new Mapper(config);
            var orders = mapper.Map<List<OrderDTO>>(data);

            return orders;
        }

        public static OrderDTO GetOrder(int id)
        {
            var data = DataAccessFactory.OrderDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });

            var mapper = new Mapper(config);
            var order = mapper.Map<OrderDTO>(data);

            return order;
        }

        public static OrderDTO AddOrder(OrderDTO orderDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
            });

            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Order>(orderDTO);
            var addO = DataAccessFactory.OrderDataAccess().Add(dbobj);

            if ( addO!= null)
            {
                return mapper.Map<OrderDTO>(addO);
            }

            return null;
        }

        public static OrderDTO UpdateOrder(OrderDTO order)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
            });

            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Order>(order);
            var ret = DataAccessFactory.OrderDataAccess().Update(dbobj);

            return mapper.Map<OrderDTO>(ret);
        }


        public static bool deleteOrder(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.OrderDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
    }
}
