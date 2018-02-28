namespace CarWash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatisticControl : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WashTypeProcesses", newName: "ProcessWashTypes");
            DropForeignKey("dbo.Orders", "Facility_ID", "dbo.Facilities");
            DropIndex("dbo.Orders", new[] { "Facility_ID" });
            RenameColumn(table: "dbo.Orders", name: "Facility_ID", newName: "FacilityID");
            DropPrimaryKey("dbo.ProcessWashTypes");
            AddColumn("dbo.Orders", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Started", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Completed", c => c.DateTime());
            AddColumn("dbo.Orders", "Aborted", c => c.DateTime());
            AddColumn("dbo.Orders", "WashTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "FacilityID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProcessWashTypes", new[] { "Process_ID", "WashType_ID" });
            CreateIndex("dbo.Orders", "WashTypeID");
            CreateIndex("dbo.Orders", "FacilityID");
            AddForeignKey("dbo.Orders", "WashTypeID", "dbo.WashTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "FacilityID", "dbo.Facilities", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "FacilityID", "dbo.Facilities");
            DropForeignKey("dbo.Orders", "WashTypeID", "dbo.WashTypes");
            DropIndex("dbo.Orders", new[] { "FacilityID" });
            DropIndex("dbo.Orders", new[] { "WashTypeID" });
            DropPrimaryKey("dbo.ProcessWashTypes");
            AlterColumn("dbo.Orders", "FacilityID", c => c.Int());
            DropColumn("dbo.Orders", "WashTypeID");
            DropColumn("dbo.Orders", "Aborted");
            DropColumn("dbo.Orders", "Completed");
            DropColumn("dbo.Orders", "Started");
            DropColumn("dbo.Orders", "Price");
            AddPrimaryKey("dbo.ProcessWashTypes", new[] { "WashType_ID", "Process_ID" });
            RenameColumn(table: "dbo.Orders", name: "FacilityID", newName: "Facility_ID");
            CreateIndex("dbo.Orders", "Facility_ID");
            AddForeignKey("dbo.Orders", "Facility_ID", "dbo.Facilities", "ID");
            RenameTable(name: "dbo.ProcessWashTypes", newName: "WashTypeProcesses");
        }
    }
}
