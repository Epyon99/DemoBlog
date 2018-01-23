namespace BlogDemo.Servicios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostClassupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinkId = c.Guid(nullable: false),
                        Text = c.String(),
                        Hypervinculo = c.String(),
                        MenuId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LinkId)
                .ForeignKey("dbo.Menues", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Menues",
                c => new
                    {
                        MenuID = c.Guid(nullable: false),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        Autor = c.String(),
                        Texto = c.String(),
                        Titulo = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        Modificaciones = c.Int(nullable: false),
                        PostType = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "MenuId", "dbo.Menues");
            DropIndex("dbo.Links", new[] { "MenuId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Menues");
            DropTable("dbo.Links");
        }
    }
}
