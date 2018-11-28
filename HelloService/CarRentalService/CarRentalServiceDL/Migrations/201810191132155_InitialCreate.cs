namespace CarRentalServiceDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Regnumber = c.String(nullable: false, maxLength: 6),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Regnumber, unique: true, name: "Unique Regnumber");
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "Unique email");
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "CarId", "dbo.Cars");
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropIndex("dbo.Reservations", new[] { "CarId" });
            DropIndex("dbo.Customers", "Unique email");
            DropIndex("dbo.Cars", "Unique Regnumber");
            DropTable("dbo.Reservations");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
        }
    }
}
