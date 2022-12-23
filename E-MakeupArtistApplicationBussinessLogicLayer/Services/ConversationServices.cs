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
    public class ConversationServices
    {
        public static List<ConversationDTO> getConversations(int id)
        {
            var data=DataAccessFactory.GetInboxSpecificConvos().getAllConversations(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Conversation, ConversationDTO>();
            });

            var mapper = new Mapper(config);
            var conversations=mapper.Map<List<ConversationDTO>>(data);

            return conversations;
        }

        public static ConversationDTO GetConversation(int id)
        {
            var data = DataAccessFactory.ConversationDataAccess().get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Conversation, ConversationDTO>();

            });

            var mapper = new Mapper(config);

            var conversation=mapper.Map<ConversationDTO>(data);

            return conversation;
        }

        public static ConversationDTO SendMessage(ConversationDTO conversationDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ConversationDTO, Conversation>();

                cfg.CreateMap<Conversation, ConversationDTO>();
            });

            var mapper = new Mapper(config);
            var dbConv = mapper.Map<Conversation>(conversationDTO);

            if (DataAccessFactory.ConversationDataAccess().Add(dbConv) != null)
            {
                return conversationDTO;
            }

            return null;
        }

        public static ConversationDTO ReplyMessage(ConversationDTO conversationDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ConversationDTO, Conversation>();

                cfg.CreateMap<Conversation, ConversationDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj=mapper.Map<Conversation>(conversationDTO);
            var updated=DataAccessFactory.ConversationDataAccess().Update(dbobj);

            return mapper.Map<ConversationDTO>(updated);
        }

        public static bool DeleteMessage(int id)
        {
            if (DataAccessFactory.ConversationDataAccess().Delete(id))
            {
                return true;
            }

            return false;
        }
    }
}
