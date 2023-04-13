namespace PeoplesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeopleSDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Peoples",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Peoples");
        }
    }
}
