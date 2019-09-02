namespace CXD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyaccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.zzd_Accounts", "Account", c => c.String(maxLength: 50, storeType: "nvarchar"));
            DropColumn("dbo.zzd_Accounts", "AccountName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.zzd_Accounts", "AccountName", c => c.String(maxLength: 50, storeType: "nvarchar"));
            DropColumn("dbo.zzd_Accounts", "Account");
        }
    }
}
