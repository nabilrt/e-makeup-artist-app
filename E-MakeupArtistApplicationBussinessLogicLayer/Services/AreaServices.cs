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
    public class AreaServices
    {
        public static List<AreaDTO> getALL()
        {
            var data=DataAccessFactory.AreaDataAccess().getALL();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Area, AreaDTO>();
            });

            var mapper = new Mapper(config);

            var areas=mapper.Map<List<AreaDTO>>(data);

            return areas;

        }

        public static AreaDTO GetArea(int id) {

            var data = DataAccessFactory.AreaDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Area, AreaDTO>();
            });

            var mapper = new Mapper(config);

            var area = mapper.Map<AreaDTO>(data);

            return area;
        }

        public static AreaDTO AddArea(AreaDTO areaDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AreaDTO,Area>();
                cfg.CreateMap<Area, AreaDTO>();
            });

            var mapper = new Mapper(config);
            var dbArea = mapper.Map<Area>(areaDTO);

            if (DataAccessFactory.AreaDataAccess().Add(dbArea) != null)
            {
                return areaDTO;
            }

            return null;
        }

        public static AreaDTO UpdateArea(AreaDTO areaDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AreaDTO, Area>();
                cfg.CreateMap<Area, AreaDTO>();
            });

            var mapper = new Mapper(config);
            var dbArea = mapper.Map<Area>(areaDTO);
            var ret=DataAccessFactory.AreaDataAccess().Update(dbArea);

            return mapper.Map<AreaDTO>(ret);
        }

        public static bool DeleteArea(int id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AreaDTO, Area>(); });
            var mapper = new Mapper(config);

            if (DataAccessFactory.AreaDataAccess().Delete(id))
            {
                return true;
            }

                return false;
        }
    }
}
