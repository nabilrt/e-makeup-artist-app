using AutoMapper;
using E_MakeupArtistApplicationBussinessLogicLayer.DTOs;
using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

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

        public static List<UserDTO> GetUnapproved()
        {
            var data=DataAccessFactory.GetUnapprovedArtists().GetUnapprovedArtists();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var users = mapper.Map<List<UserDTO>>(data);

            return users;

        }

        public static bool approveUser(int id)
        {
            var data=DataAccessFactory.GetApproveUser().ApproveUser(id);

            if (data != null)
            {
                MailAddress to = new MailAddress(data.Email);
                MailAddress from = new MailAddress("19-41607-3@student.aiub.edu");
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Approval of Joining E-Makeup-Artist-App";
                message.Body = "Congratulations your join request has been approved. Thanks for joining us and contributing to the society";
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587)
                {
                    Credentials = new NetworkCredential("19-41607-3@student.aiub.edu", "19417243/Nabil"),
                    EnableSsl = true
                };

                client.Send(message);

                return true;
            }

            return false;
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
