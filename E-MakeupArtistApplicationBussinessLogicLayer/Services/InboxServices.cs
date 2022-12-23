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
    public class InboxServices
    {
        public static List<InboxDTO> getArtistMessages(ArtistDTO artist)
        {
            var data=DataAccessFactory.GetMessages().getArtistOnlyInbox(artist.Id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Inbox, InboxDTO>();
            });
            var mapper = new Mapper(config);
            var inboxes=mapper.Map<List<InboxDTO>>(data);

            return inboxes;

        }

        public static List<InboxDTO> getCustomerMessages(CustomerDTO customer)
        {
            var data = DataAccessFactory.GetMessages().getCustomerOnlyInbox(customer.Id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Inbox, InboxDTO>();
            });
            var mapper = new Mapper(config);
            var inboxes = mapper.Map<List<InboxDTO>>(data);

            return inboxes;
        }

        public static InboxDTO addInbox(InboxDTO inbox)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InboxDTO, Inbox>();
                cfg.CreateMap<Inbox, InboxDTO>();
            });

            var mapper = new Mapper(config);
            var dbInbox = mapper.Map<Inbox>(inbox);

            if (DataAccessFactory.InboxDataAccess().Add(dbInbox) != null)
            {
                return inbox;
            }

            return null;
        }

        public static bool deleteInbox(int id)
        {
            if (DataAccessFactory.GetInboxSpecificConvos().deleteInboxConvos(id))
            {
                if (DataAccessFactory.InboxDataAccess().Delete(id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
