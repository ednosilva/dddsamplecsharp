namespace BM.GestaoProblema.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analista",
                c => new
                    {
                        AnalistaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        TimeSuporteId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.AnalistaId)
                .ForeignKey("dbo.TimeSuporte", t => t.TimeSuporteId)
                .Index(t => t.TimeSuporteId);
            
            CreateTable(
                "dbo.TimeSuporte",
                c => new
                    {
                        TimeSuporteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 500, unicode: false),
                        DataCriacao = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.TimeSuporteId);
            
            CreateTable(
                "dbo.Chamado",
                c => new
                    {
                        ChamadoId = c.Guid(nullable: false),
                        DataInicioAtendimento = c.DateTime(storeType: "smalldatetime"),
                        DataFinalizado = c.DateTime(storeType: "smalldatetime"),
                        AnalistaId = c.Int(),
                        SistemaId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Prioridade = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.ChamadoId)
                .ForeignKey("dbo.Analista", t => t.AnalistaId)
                .ForeignKey("dbo.Sistema", t => t.SistemaId)
                .Index(t => t.AnalistaId)
                .Index(t => t.SistemaId);
            
            CreateTable(
                "dbo.Sistema",
                c => new
                    {
                        SistemaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        TimeSuporteId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.SistemaId)
                .ForeignKey("dbo.TimeSuporte", t => t.TimeSuporteId)
                .Index(t => t.TimeSuporteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chamado", "SistemaId", "dbo.Sistema");
            DropForeignKey("dbo.Sistema", "TimeSuporteId", "dbo.TimeSuporte");
            DropForeignKey("dbo.Chamado", "AnalistaId", "dbo.Analista");
            DropForeignKey("dbo.Analista", "TimeSuporteId", "dbo.TimeSuporte");
            DropIndex("dbo.Sistema", new[] { "TimeSuporteId" });
            DropIndex("dbo.Chamado", new[] { "SistemaId" });
            DropIndex("dbo.Chamado", new[] { "AnalistaId" });
            DropIndex("dbo.Analista", new[] { "TimeSuporteId" });
            DropTable("dbo.Sistema");
            DropTable("dbo.Chamado");
            DropTable("dbo.TimeSuporte");
            DropTable("dbo.Analista");
        }
    }
}
