namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialdealershipdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Manufacture = c.String(),
                        Year = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Run = c.Single(nullable: false),
                        AddInfo = c.String(),
                        Pic = c.Binary(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Owner_Id", "dbo.Owners");
            DropIndex("dbo.Cars", new[] { "Owner_Id" });
            DropTable("dbo.Owners");
            DropTable("dbo.Cars");
        }
    }
}
