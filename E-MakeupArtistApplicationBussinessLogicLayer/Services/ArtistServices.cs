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
    public class ArtistServices
    {
        public static List<ArtistDTO> getALL()
        {
            var data=DataAccessFactory.ArtistDataAccess().getALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistDTO>();
            });
            var mapper = new Mapper(config);
            var artists = mapper.Map<List<ArtistDTO>>(data);

            return artists;
        }

        public static ArtistDTO get(int id)
        {
            var data = DataAccessFactory.ArtistDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistDTO>();
            });
            var mapper = new Mapper(config);
            var artist = mapper.Map<ArtistDTO>(data);
            return artist;
        }

        public static ArtistDTO addArtist(ArtistDTO art)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtistDTO, Artist>();
                cfg.CreateMap<Artist, ArtistDTO>();
            });

            var mapper = new Mapper(config);
            var dbartist = mapper.Map<Artist>(art);

            if (DataAccessFactory.ArtistDataAccess().Add(dbartist) != null)
            {
                return art;
            }

            return null;
        }

        public static ArtistDTO updateArtist(ArtistDTO art)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<ArtistDTO, Artist>();
                c.CreateMap<Artist, ArtistDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Artist>(art);
            var ret = DataAccessFactory.ArtistDataAccess().Update(dbobj);
            return mapper.Map<ArtistDTO>(ret);
        }

        public static bool deleteArtist(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArtistDTO, Artist>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.ArtistDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
    }
}
