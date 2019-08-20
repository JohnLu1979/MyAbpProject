namespace CXD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.zzd_user");
        }
    }
}
