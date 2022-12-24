using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
using E_MakeupArtistApplicationDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.Services
{
    public class UserCustomerServices
    {
        public static List<UserCustomerDTO> getALL()
        {
            var Users = DataAccessFactory.UserDataAccess().getALL();
            var Customers=DataAccessFactory.CustomerDataAccess().getALL();
            var userCustomers=new List<UserCustomerDTO>();

            foreach(var user in Customers)
            {
                var us = (from u in Users where u.Id == user.Id select u).SingleOrDefault();

                userCustomers.Add(new UserCustomerDTO()
                {
                    Id = us.Id,
                    Username = us.Username,
                    Password = us.Password,
                    Email = us.Email,
                    User_Type = us.User_Type,
                    Is_Approved = us.Is_Approved,
                    Name=user.Name,
                    DOB=user.DOB,
                    AreaId=user.AreaId,
                    Address=user.Address,
                    Is_Premium=user.Is_Premium
                });

            }

            return userCustomers;
        }

        public static UserCustomerDTO GetUserCustomer(int id)
        {
            var User=DataAccessFactory.UserDataAccess().get(id);
            var Customer=DataAccessFactory.CustomerDataAccess().get(id);

            if(User!=null && Customer != null)
            {
                var artistUser = new UserCustomerDTO()
                {
                    Id= User.Id,
                    Username= User.Username,
                    Password= User.Password,
                    Email= User.Email,  
                    User_Type= User.User_Type,
                    Is_Approved= User.Is_Approved,
                    Name=Customer.Name,
                    DOB=Customer.DOB,
                    AreaId=Customer.AreaId,
                    Address=Customer.Address,   
                    Is_Premium=Customer.Is_Premium
                };

                return artistUser;
            }

            return null;
        }

        public static UserCustomerDTO AddUserCustomer(UserCustomerDTO userCustomerDTO)
        {
            var User = UserServices.addUser(new UserDTO
            {
                Username = userCustomerDTO.Username,
                Password = userCustomerDTO.Password,
                Email = userCustomerDTO.Email,
                User_Type = userCustomerDTO.User_Type,
                Is_Approved = userCustomerDTO.Is_Approved
            });

            var Customer = CustomerServices.addCustomer(new CustomerDTO()
            {
                Id=User.Id,
                Name=userCustomerDTO.Name,
                DOB=userCustomerDTO.DOB,
                AreaId=userCustomerDTO.AreaId,
                Address=userCustomerDTO.Address,
                Is_Premium=userCustomerDTO.Is_Premium
            });

            if(User!=null && Customer!=null)
            {
                var newUserCustomer = new UserCustomerDTO()
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    Email = User.Email,
                    User_Type = User.User_Type,
                    Is_Approved = User.Is_Approved,
                    Name = Customer.Name,
                    DOB = Customer.DOB,
                    AreaId = Customer.AreaId,
                    Address = Customer.Address,
                    Is_Premium = Customer.Is_Premium
                };

                return newUserCustomer;
            }

            return null;
        }

        public static UserCustomerDTO UpdateUserCustomer(UserCustomerDTO userCustomerDTO)
        {
            var User = UserServices.updateUser(new UserDTO
            {
                Id= userCustomerDTO.Id,
                Username = userCustomerDTO.Username,
                Password = userCustomerDTO.Password,
                Email = userCustomerDTO.Email,
                User_Type = userCustomerDTO.User_Type,
                Is_Approved = userCustomerDTO.Is_Approved
            });

            var Customer = CustomerServices.updateCustomer(new CustomerDTO()
            {
                Id = User.Id,
                Name = userCustomerDTO.Name,
                DOB = userCustomerDTO.DOB,
                AreaId = userCustomerDTO.AreaId,
                Address = userCustomerDTO.Address,
                Is_Premium = userCustomerDTO.Is_Premium
            });

            if (User != null && Customer != null)
            {
                var newUserCustomer = new UserCustomerDTO()
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    Email = User.Email,
                    User_Type = User.User_Type,
                    Is_Approved = User.Is_Approved,
                    Name = Customer.Name,
                    DOB = Customer.DOB,
                    AreaId = Customer.AreaId,
                    Address = Customer.Address,
                    Is_Premium = Customer.Is_Premium
                };

                return newUserCustomer;
            }

            return null;
        }

        public static bool DeleteUserCustomer(int id)
        {
            if (CustomerServices.deleteCustomer(id))
            {
                if (UserServices.deleteUser(id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
