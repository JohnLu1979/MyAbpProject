namespace CXD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tide : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.zzd_user");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.zzd_user",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
