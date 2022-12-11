using AutoMapper;
using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.Services
{
    public class UserServices
    {
        public static List<UserDTO> getALL()
        {
            var data = DataAccessFactory.UserDataAccess().getALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var users = mapper.Map<List<UserDTO>>(data);

            return users;
        }

        public static UserDTO get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var user = mapper.Map<UserDTO>(data);
            return user;
        }

        public static UserDTO addUser(UserDTO art)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);
            var dbartist = mapper.Map<User>(art);
            var dbuser = DataAccessFactory.UserDataAccess().Add(dbartist);

            if (dbuser != null)
            {
                return mapper.Map<UserDTO>(dbuser);
            }

            return null;
        }

        public static UserDTO updateUser(UserDTO art)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<User>(art);
            var ret = DataAccessFactory.UserDataAccess().Update(dbobj);

            return mapper.Map<UserDTO>(ret);
        }

        public static bool deleteUser(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.UserDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
    }
}
