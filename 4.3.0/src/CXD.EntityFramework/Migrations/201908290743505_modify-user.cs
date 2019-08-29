namespace CXD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.zzd_user", "CompanyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.zzd_user", "CompanyId");
        }
    }
}
