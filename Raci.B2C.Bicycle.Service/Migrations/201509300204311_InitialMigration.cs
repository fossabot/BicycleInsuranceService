namespace Raci.B2C.Bicycle.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoverOptions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AnnualPremium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumAgreedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumAgreedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Excess = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PolicyNumber = c.String(),
                        Description = c.String(),
                        State = c.Int(nullable: false),
                        DetailId = c.Long(),
                        ContactId = c.Long(),
                        OptionId = c.Long(),
                        PaymentId = c.Long(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PolicyContacts", t => t.ContactId)
                .ForeignKey("dbo.BicyclePolicyDetails", t => t.DetailId)
                .ForeignKey("dbo.PolicyOptions", t => t.OptionId)
                .ForeignKey("dbo.PaymentDetails", t => t.PaymentId)
                .Index(t => t.DetailId)
                .Index(t => t.ContactId)
                .Index(t => t.OptionId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.PolicyContacts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsPrimary = c.Boolean(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        AddressId = c.Long(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false),
                        Suburb = c.String(nullable: false),
                        PostCode = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BicyclePolicyDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.String(),
                        Type = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PolicyOptions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AnnualPremium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Excess = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AgreedValue = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransactionId = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "PaymentId", "dbo.PaymentDetails");
            DropForeignKey("dbo.Policies", "OptionId", "dbo.PolicyOptions");
            DropForeignKey("dbo.Policies", "DetailId", "dbo.BicyclePolicyDetails");
            DropForeignKey("dbo.Policies", "ContactId", "dbo.PolicyContacts");
            DropForeignKey("dbo.PolicyContacts", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PolicyContacts", new[] { "AddressId" });
            DropIndex("dbo.Policies", new[] { "PaymentId" });
            DropIndex("dbo.Policies", new[] { "OptionId" });
            DropIndex("dbo.Policies", new[] { "ContactId" });
            DropIndex("dbo.Policies", new[] { "DetailId" });
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.PolicyOptions");
            DropTable("dbo.BicyclePolicyDetails");
            DropTable("dbo.Addresses");
            DropTable("dbo.PolicyContacts");
            DropTable("dbo.Policies");
            DropTable("dbo.CoverOptions");
        }
    }
}
