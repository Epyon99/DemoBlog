namespace BlogDemo.Servicios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateTypeinPOst : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "FechaCreacion", c => c.String());
            AlterColumn("dbo.Posts", "FechaModificacion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "FechaModificacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
