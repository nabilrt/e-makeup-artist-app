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
    public class FeedbackServices
    {
        public static List<FeedbackDTO> getALL()
        {
            var data=DataAccessFactory.FeedbackDataAccess().getALL();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Feedback, FeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var feedbacks=mapper.Map<List<FeedbackDTO>>(data);  

            return feedbacks;
        }

        public static FeedbackDTO get(int id)
        {
            var data=DataAccessFactory.FeedbackDataAccess().get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Feedback, FeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var feedback = mapper.Map<FeedbackDTO>(data);
            return feedback;
        }

        public static FeedbackDTO addFeedback(FeedbackDTO feedback)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FeedbackDTO, Feedback>();
                cfg.CreateMap<Feedback, FeedbackDTO>();
            });

            var mapper = new Mapper(config);
            var dbfeedback=mapper.Map<Feedback>(feedback);

            if (DataAccessFactory.FeedbackDataAccess().Add(dbfeedback) != null)
            {
                return feedback;
            }

            return null;
        }

        public static bool updateFeedback(FeedbackDTO feedback)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO, Feedback>());
            var mapper = new Mapper(config);
            var feedbackItem = mapper.Map<Feedback>(feedback);

            if (DataAccessFactory.FeedbackDataAccess().Update(feedbackItem) != null)
            {
                return true;
            }

            return false;
        }

        public static bool deleteFeedback(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO, Feedback>());
            var mapper = new Mapper(config);

            if (DataAccessFactory.FeedbackDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
    }
}
