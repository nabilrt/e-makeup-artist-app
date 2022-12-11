namespace E_MakeupArtistApplicationDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        User_Type = c.String(),
                        Is_Approved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                        AreaId = c.Int(nullable: false),
                        Portfolio_Link = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                        AreaId = c.Int(nullable: false),
                        Address = c.String(),
                        Is_Premium = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InboxId = c.Int(nullable: false),
                        Message = c.String(),
                        Reply = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inboxes", t => t.InboxId, cascadeDelete: true)
                .Index(t => t.InboxId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        ArtistId = c.Int(),
                        TotalPrice = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Offered_By = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Offered_By)
                .Index(t => t.Offered_By);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenDetails = c.String(),
                        Creation_Time = c.DateTime(nullable: false),
                        Expired_At = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PaymentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "Id", "dbo.Users");
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Artists", "Id", "dbo.Users");
            DropForeignKey("dbo.Artists", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Customers", "Id", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Packages", "Offered_By", "dbo.Artists");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Inboxes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Conversations", "InboxId", "dbo.Inboxes");
            DropForeignKey("dbo.Inboxes", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Customers", "AreaId", "dbo.Areas");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "User_Id" });
            DropIndex("dbo.Packages", new[] { "Offered_By" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "PackageId" });
            DropIndex("dbo.Orders", new[] { "ArtistId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Conversations", new[] { "InboxId" });
            DropIndex("dbo.Inboxes", new[] { "ArtistId" });
            DropIndex("dbo.Inboxes", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "AreaId" });
            DropIndex("dbo.Customers", new[] { "Id" });
            DropIndex("dbo.Artists", new[] { "AreaId" });
            DropIndex("dbo.Artists", new[] { "Id" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropTable("dbo.PaymentInfoes");
            DropTable("dbo.Tokens");
            DropTable("dbo.Payments");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Packages");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Conversations");
            DropTable("dbo.Inboxes");
            DropTable("dbo.Customers");
            DropTable("dbo.Areas");
            DropTable("dbo.Artists");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
