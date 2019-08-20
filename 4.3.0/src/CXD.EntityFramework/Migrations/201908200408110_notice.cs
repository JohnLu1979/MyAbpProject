namespace CXD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notice", "Title", c => c.String(unicode: false));
            AlterColumn("dbo.Notice", "NewsAuthor", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notice", "NewsAuthor", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Notice", "Title", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}
