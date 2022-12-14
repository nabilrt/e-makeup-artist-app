using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using E_MakeupArtistApplicationDataAccessLayer.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer
{
    public class DataAccessFactory
    {
        public static IBasicOperations<User,int,bool> UserDataAccess()
        {
            return new UserOperations();
        }

        public static IBasicOperations<Artist, int, bool> ArtistDataAccess()
        {
            return new ArtistOperations();
        }

        public static IBasicOperations<Customer, int, bool> CustomerDataAccess()
        {
            return new CustomerOperations();
        }

        public static IBasicOperations<Token, string, bool> TokenDataAccess()
        {
            return new TokenOperations();
        }

        public static IBasicOperations<Payment, int, bool> PaymentDataAccess()
        {
            return new PaymentOperations();
        }

        public static IBasicOperations<PaymentInfo, int, bool> PaymentInfoDataAccess()
        {
            return new PaymentInfosOperations();
        }

        public static IBasicOperations<Inbox, int, bool> InboxDataAccess()
        {
            return new InboxOperations();
        }

        public static IBasicOperations<Conversation, int, bool> ConversationDataAccess()
        {
            return new ConversationOperations();
        }

        public static IBasicOperations<Feedback, int, bool> FeedbackDataAccess()
        {
            return new FeedbackOperations();
        }

        public static IBasicOperations<Package, int, bool> PackageDataAccess()
        {
            return new PackageOperations();
        }

        public static IBasicOperations<Order, int, bool> OrderDataAccess()
        {
            return new OrderOperations();
        }

        public static IBasicOperations<OrderDetail, int, bool> OrderDetailDataAccess()
        {
            return new OrderDetailOperations();
        }

        public static IBasicOperations<Area, int, bool> AreaDataAccess()
        {
            return new AreaOperations();
        }

        public static IBasicOperations<Admin, int, bool> AdminDataAccess()
        {
            return new AdminOperations();
        }

        public static IAuth<User> LoginDataAccess()
        {
            return new UserOperations();
        }

        public static IPersonalMessages<Inbox> GetMessages()
        {
            return new InboxOperations();
        }

        public static IConversations<Conversation> GetInboxSpecificConvos()
        {
            return new ConversationOperations();
        }

        public static IPremiumMember<Customer> GetPremiumMember()
        {
            return new CustomerOperations();
        }

        public static IPackageByArtist<Package> GetPackageByArtist()
        {
            return new PackageOperations();
        }

        public static IOrderByUser<Order> GetOrderByUser()
        {
            return new OrderOperations();
        }

        public static IDetailsByOrder<OrderDetail> GetOrderById()
        {
            return new OrderDetailOperations();
        }

        public static ITokenExpire<Token> GetTokenExpire()
        {
            return new TokenOperations();
        }

        public static IUnapprovedArtists<User> GetUnapprovedArtists()
        {
            return new UserOperations();
        }

        public static IApproveUser<User> GetApproveUser()
        {
            return new UserOperations();
        }
      
    }
}
