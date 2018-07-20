namespace NpgsqlIssue105.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        SettingType = c.Int(nullable: false),
                        SettingValue = c.String(),
                    })
                .PrimaryKey(t => new { t.UserId, t.SettingType });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
