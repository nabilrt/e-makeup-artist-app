using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB
{
    public class EMakeupContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail > OrderDetails { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }
        public DbSet<Conversation > Conversations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment > Payments { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
