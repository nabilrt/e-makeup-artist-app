using AutoMapper;
using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
using E_MakeupArtistApplicationDataAccessLayer;
using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using System.Collections.Generic;

namespace E_MakeupArtistApplicationBussinessLogicLayer.Services
{
    public class CustomerServices
    {
        public static List<CustomerDTO> GetAllCustomers()
        {
            var data=DataAccessFactory.CustomerDataAccess().getALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
            });

            var mapper=new Mapper(config);
            var customers=mapper.Map<List<CustomerDTO>>(data);

            return customers;
        }

        public static CustomerDTO GetCustomer(int id)
        {
            var data=DataAccessFactory.CustomerDataAccess().get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper=new Mapper(config);
            var customer=mapper.Map<CustomerDTO>(data);

            return customer;
        }

        public static CustomerDTO addCustomer(CustomerDTO customer)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });

            var mapper=new Mapper(config);
            var dbCustomer = mapper.Map<Customer>(customer);

            if (DataAccessFactory.CustomerDataAccess().Add(dbCustomer) != null)
            {
                return customer;
            }

            return null;
        }

        public static CustomerDTO updateCustomer(CustomerDTO customer)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });

            var mapper = new Mapper(config);
            var dbCustomer = mapper.Map<Customer>(customer);
            var ret=DataAccessFactory.CustomerDataAccess().Update(dbCustomer);

            return mapper.Map<CustomerDTO>(ret);
        }

        public static bool deleteCustomer(int id)
        {
            var config=new MapperConfiguration(cfg => { cfg.CreateMap<CustomerDTO,Customer>(); });
            var mapper=new Mapper(config);

            if (DataAccessFactory.CustomerDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
        public static bool IsPremiumCustomer(CustomerDTO customer)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
            });

            var mapper = new Mapper(config);
            var dbcustomer = mapper.Map<Customer>(customer);

            if (DataAccessFactory.GetPremiumMember().IsPremiumMember(dbcustomer))
            {
                return true;
            }

            return false;
        }
    }
}
