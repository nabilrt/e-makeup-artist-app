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
    public class UserAdminService
    {
        public static List<UserAdminDTO> getALL()
        {
            var Users = DataAccessFactory.UserDataAccess().getALL();
            var Admins = DataAccessFactory.AdminDataAccess().getALL();
            var userAdmins = new List<UserAdminDTO>();

            foreach (var user in Admins)
            {
                var us = (from u in Users where u.Id == user.Id select u).SingleOrDefault();

                userAdmins.Add(new UserAdminDTO()
                {
                    Id = us.Id,
                    Username = us.Username,
                    Password = us.Password,
                    Email = us.Email,
                    User_Type = us.User_Type,
                    Is_Approved = us.Is_Approved,
                    Name = user.Name,
                    DOB = user.DOB,
                    
                });
            }

            return userAdmins;
        }

        public static UserAdminDTO Get(int id)
        {
            var User = DataAccessFactory.UserDataAccess().get(id);
            var Admin = DataAccessFactory.AdminDataAccess().get(id);

            if (User != null && Admin != null)
            {
                var AdminUser = new UserAdminDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    User_Type = User.User_Type,
                    Name = Admin.Name,
                    Email = User.Email,
                    DOB = Admin.DOB,
                  

                };
                return AdminUser;
            }
            return null;
        }

        public static UserAdminDTO Add(UserAdminDTO userAdminDTO)
        {
            var User = UserServices.addUser(new UserDTO
            {
                Username = userAdminDTO.Username,
                Password = userAdminDTO.Password,
                Email = userAdminDTO.Email,
                User_Type = userAdminDTO.User_Type,
                Is_Approved = userAdminDTO.Is_Approved
            });

            var Admin = AdminService.addAdmin(new AdminDTO
            {
                Id = User.Id,
               
                DOB = userAdminDTO.DOB,
               
                Name = userAdminDTO.Name
            });

            if (User != null && Admin != null)
            {
                var newUserAdmin = new UserAdminDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Email = User.Email,
                    Password = User.Password,
                    User_Type = User.User_Type,
                    Is_Approved = User.Is_Approved,
                    Name = Admin.Name,
                    DOB = Admin.DOB,
                   

                };

                return newUserAdmin;
            }

            return null;
        }

        public static UserAdminDTO Update(UserAdminDTO userAdminDTO)
        {
            var User = UserServices.updateUser(new UserDTO
            {
                Id = userAdminDTO.Id,
                Username = userAdminDTO.Username,
                Password = userAdminDTO.Password,
                Email = userAdminDTO.Email,
                User_Type = userAdminDTO.User_Type,
                Is_Approved = userAdminDTO.Is_Approved
            });

            var Admin = AdminService.updateAdmin(new AdminDTO
            {
                Id = userAdminDTO.Id,
                
                DOB = userAdminDTO.DOB,
               
                Name = userAdminDTO.Name
            });

            if (User != null && Admin != null)
            {
                var newUserAdmin = new UserAdminDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Email = User.Email,
                    Password = User.Password,
                    User_Type = User.User_Type,
                    Is_Approved = User.Is_Approved,
                    Name = Admin.Name,
                    DOB = Admin.DOB,
                   

                };

                return newUserAdmin;
            }

            return null;
        }

        public static bool delete(int id)
        {
            if (AdminService.deleteAdmin(id))
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
