namespace CXD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyaccount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "IMEICode", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "IMEICode", c => c.Int(nullable: false));
        }
    }
}
