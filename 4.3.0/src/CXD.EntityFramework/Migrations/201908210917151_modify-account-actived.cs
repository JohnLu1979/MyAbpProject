namespace CXD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyaccountactived : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "IsActivated", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "IsActivated", c => c.Boolean(nullable: false));
        }
    }
}
