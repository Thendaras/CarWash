namespace CarWash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Facility_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Facilities", t => t.Facility_ID)
                .Index(t => t.Facility_ID);
            
            CreateTable(
                "dbo.Processes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Priority = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WashTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WashTypeProcesses",
                c => new
                    {
                        WashType_ID = c.Int(nullable: false),
                        Process_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WashType_ID, t.Process_ID })
                .ForeignKey("dbo.WashTypes", t => t.WashType_ID, cascadeDelete: true)
                .ForeignKey("dbo.Processes", t => t.Process_ID, cascadeDelete: true)
                .Index(t => t.WashType_ID)
                .Index(t => t.Process_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WashTypeProcesses", "Process_ID", "dbo.Processes");
            DropForeignKey("dbo.WashTypeProcesses", "WashType_ID", "dbo.WashTypes");
            DropForeignKey("dbo.Orders", "Facility_ID", "dbo.Facilities");
            DropIndex("dbo.WashTypeProcesses", new[] { "Process_ID" });
            DropIndex("dbo.WashTypeProcesses", new[] { "WashType_ID" });
            DropIndex("dbo.Orders", new[] { "Facility_ID" });
            DropTable("dbo.WashTypeProcesses");
            DropTable("dbo.WashTypes");
            DropTable("dbo.Processes");
            DropTable("dbo.Orders");
            DropTable("dbo.Facilities");
        }
    }
}
