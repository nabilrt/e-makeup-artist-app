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
    public class UserArtistServices
    {
        public static List<UserArtistDTO> getALL()
        {
            var Users = DataAccessFactory.UserDataAccess().getALL();
            var Artists = DataAccessFactory.ArtistDataAccess().getALL();
            var userArtists = new List<UserArtistDTO>();

            foreach (var user in Artists)
            {
                var us = (from u in Users where u.Id == user.Id select u).SingleOrDefault();

                userArtists.Add(new UserArtistDTO()
                {
                    Id = us.Id,
                    Username = us.Username,
                    Password = us.Password,
                    Email = us.Email,
                    User_Type = us.User_Type,
                    Is_Approved = us.Is_Approved,
                    Name = user.Name,
                    DOB = user.DOB,
                    AreaId = user.AreaId,
                    Portfolio_Link = user.Portfolio_Link
                });
            }

            return userArtists;
        }

        public static UserArtistDTO Get(int id)
        {
            var User = DataAccessFactory.UserDataAccess().get(id);
            var Artist = DataAccessFactory.ArtistDataAccess().get(id);

            if (User != null && Artist != null)
            {
                var ArtistUser = new UserArtistDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Password = User.Password,
                    User_Type = User.User_Type,
                    Name = Artist.Name,
                    Email = User.Email,
                    DOB = Artist.DOB,
                    AreaId = Artist.AreaId,
                    Portfolio_Link = Artist.Portfolio_Link,

                };
                return ArtistUser;
            }
            return null;
        }

        public static UserArtistDTO Add(UserArtistDTO userArtistDTO)
        {
            var User = UserServices.addUser(new UserDTO { Username = userArtistDTO.Username, Password = userArtistDTO.Password, Email=userArtistDTO.Email, User_Type=userArtistDTO.User_Type,
            Is_Approved=userArtistDTO.Is_Approved});

            var Artist = ArtistServices.addArtist(new ArtistDTO
            {
                Id= User.Id,
                AreaId=userArtistDTO.AreaId,
                DOB=userArtistDTO.DOB,
                Portfolio_Link=userArtistDTO.Portfolio_Link,
                Name=userArtistDTO.Name
            });

            if(User!=null && Artist!=null)
            {
                var newUserArtist = new UserArtistDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Email = User.Email,
                    Password = User.Password,
                    User_Type = User.User_Type,
                    Is_Approved = User.Is_Approved,
                    Name = Artist.Name,
                    DOB = Artist.DOB,
                    Portfolio_Link = Artist.Portfolio_Link,
                    AreaId = Artist.AreaId,

                };

                return newUserArtist;
            }

            return null;
         }

        public static UserArtistDTO Update(UserArtistDTO userArtistDTO)
        {
            var User = UserServices.updateUser(new UserDTO
            {
                Id= userArtistDTO.Id,
                Username = userArtistDTO.Username,
                Password = userArtistDTO.Password,
                Email = userArtistDTO.Email,
                User_Type = userArtistDTO.User_Type,
                Is_Approved = userArtistDTO.Is_Approved
            });

            var Artist = ArtistServices.updateArtist(new ArtistDTO
            {
                Id = userArtistDTO.Id,
                AreaId = userArtistDTO.AreaId,
                DOB = userArtistDTO.DOB,
                Portfolio_Link = userArtistDTO.Portfolio_Link,
                Name = userArtistDTO.Name
            });

            if (User != null && Artist != null)
            {
                var newUserArtist = new UserArtistDTO
                {
                    Id = User.Id,
                    Username = User.Username,
                    Email = User.Email,
                    Password = User.Password,
                    User_Type = User.User_Type,
                    Is_Approved = User.Is_Approved,
                    Name = Artist.Name,
                    DOB = Artist.DOB,
                    Portfolio_Link = Artist.Portfolio_Link,
                    AreaId = Artist.AreaId,

                };

                return newUserArtist;
            }

            return null;
        }

        public static bool delete(int id)
        {
            if(ArtistServices.deleteArtist(id))
            {
                if(UserServices.deleteUser(id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
