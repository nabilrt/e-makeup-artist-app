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
    public class AuthServices
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var user = DataAccessFactory.LoginDataAccess().Authenticate(username, password);
            if (user != null)
            {
                var tk = new Token();
                tk.UserId = user.Id;
                tk.Creation_Time= DateTime.Now;
                tk.Expired_At = null;
                tk.TokenDetails = Guid.NewGuid().ToString();
                var rttk = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rttk != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var data = mapper.Map<TokenDTO>(rttk);
                    return data;
                }
            }
            return null;
        }

        public static TokenDTO IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().get(token);
            if (tk != null && tk.Expired_At == null)
            {
                var cfg = new MapperConfiguration(c => {
                    c.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(cfg);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;


        }

        public static bool ExpToken(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().get(token);
            if (tk != null && tk.Expired_At == null)
            {
                tk.Expired_At = DateTime.Now;
                var uptk = DataAccessFactory.TokenDataAccess().Update(tk);
                if (uptk != null)
                {
                    return true;
                }
                return false;

            }
            return false;


        }
    }
}
