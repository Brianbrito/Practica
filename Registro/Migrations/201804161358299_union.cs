namespace Registro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class union : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccions", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.Direccions", new[] { "Persona_Id" });
            DropTable("dbo.Personas");
            DropTable("dbo.Direccions");
        }
    }
}
