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
    public class PackageServices
    {
        public static List<PackageDTO> getALL()
        {
            var data = DataAccessFactory.PackageDataAccess().getALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Package, FeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var packages = mapper.Map<List<PackageDTO>>(data);

            return packages;
        }

        public static PackageDTO get(int id)
        {
            var data = DataAccessFactory.PackageDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Package, PackageDTO>();
            });
            var mapper = new Mapper(config);
            var package = mapper.Map<PackageDTO>(data);
            return package;
        }

        public static PackageDTO addPackage(PackageDTO package)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackageDTO, Package>();
                cfg.CreateMap<Package, PackageDTO>();
            });

            var mapper = new Mapper(config);
            var dbpackage = mapper.Map<Package>(package);

            if (DataAccessFactory.PackageDataAccess().Add(dbpackage) != null)
            {
                return package;
            }

            return null;
        }

        public static bool updatePackage(PackageDTO package)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageDTO, Package>());
            var mapper = new Mapper(config);
            var packageItem = mapper.Map<Package>(package);

            if (DataAccessFactory.PackageDataAccess().Update(packageItem) != null)
            {
                return true;
            }

            return false;
        }

        public static bool deletePackage(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PackageDTO, Package>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.PackageDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
    }
}
