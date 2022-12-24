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
    public class AdminService
    {
        public static List<AdminDTO> getALL()
        {
            var data = DataAccessFactory.AdminDataAccess().getALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var admins = mapper.Map<List<AdminDTO>>(data);

            return admins;
        }
        public static AdminDTO get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var admin = mapper.Map<AdminDTO>(data);
            return admin;
        }

        public static AdminDTO addAdmin(AdminDTO adm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });

            var mapper = new Mapper(config);
            var dbadmin = mapper.Map<Admin>(adm);

            if (DataAccessFactory.AdminDataAccess().Add(dbadmin) != null)
            {
                return adm;
            }

            return null;
        }

        public static AdminDTO updateAdmin(AdminDTO adm)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Admin>(adm);
            var ret = DataAccessFactory.AdminDataAccess().Update(dbobj);
            return mapper.Map<AdminDTO>(ret);
        }

        public static bool deleteAdmin(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AdminDTO, Admin>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.AdminDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }

    }
}
