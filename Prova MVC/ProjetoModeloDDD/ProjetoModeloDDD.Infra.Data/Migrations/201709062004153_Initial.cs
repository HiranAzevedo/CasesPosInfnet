namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Produto", new[] { "ClienteId" });
            CreateTable(
                "dbo.Comentario",
                c => new
                {
                    IdComentario = c.Int(nullable: false, identity: true),
                    Text = c.String(maxLength: 100, unicode: false),
                    IdPerfil = c.Int(nullable: false),
                    IdPublicacao = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.IdComentario)
                .ForeignKey("dbo.Perfil", t => t.IdPerfil)
                .ForeignKey("dbo.Publicacao", t => t.IdPublicacao)
                .Index(t => t.IdPerfil)
                .Index(t => t.IdPublicacao);

            CreateTable(
                "dbo.Perfil",
                c => new
                {
                    IdConta = c.Int(nullable: false),
                    Nome = c.String(maxLength: 100, unicode: false),
                    Sobrenome = c.String(maxLength: 100, unicode: false),
                    Local = c.String(maxLength: 100, unicode: false),
                })
                .PrimaryKey(t => t.IdConta)
                .ForeignKey("dbo.Conta", t => t.IdConta)
                .Index(t => t.IdConta);

            CreateTable(
                "dbo.Conta",
                c => new
                {
                    IdConta = c.Int(nullable: false, identity: true),
                    NomeUsuario = c.String(maxLength: 100, unicode: false),
                    Senha = c.String(maxLength: 100, unicode: false),
                })
                .PrimaryKey(t => t.IdConta);

            CreateTable(
                "dbo.Publicacao",
                c => new
                {
                    IdPublicacao = c.Int(nullable: false, identity: true),
                    IdPerfil = c.Int(nullable: false),
                    Conteudo = c.String(maxLength: 100, unicode: false),
                })
                .PrimaryKey(t => t.IdPublicacao)
                .ForeignKey("dbo.Perfil", t => t.IdPerfil)
                .Index(t => t.IdPerfil);

            DropTable("dbo.Cliente");
            DropTable("dbo.Produto");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                {
                    ProdutoId = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                    Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Disponivel = c.Boolean(nullable: false),
                    ClienteId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ProdutoId);

            CreateTable(
                "dbo.Cliente",
                c => new
                {
                    ClienteId = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                    Sobrenome = c.String(nullable: false, maxLength: 150, unicode: false),
                    Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    DataCadastro = c.DateTime(nullable: false),
                    Ativo = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ClienteId);

            DropForeignKey("dbo.Publicacao", "IdPerfil", "dbo.Perfil");
            DropForeignKey("dbo.Comentario", "IdPublicacao", "dbo.Publicacao");
            DropForeignKey("dbo.Comentario", "IdPerfil", "dbo.Perfil");
            DropForeignKey("dbo.Perfil", "IdConta", "dbo.Conta");
            DropIndex("dbo.Publicacao", new[] { "IdPerfil" });
            DropIndex("dbo.Perfil", new[] { "IdConta" });
            DropIndex("dbo.Comentario", new[] { "IdPublicacao" });
            DropIndex("dbo.Comentario", new[] { "IdPerfil" });
            DropTable("dbo.Publicacao");
            DropTable("dbo.Conta");
            DropTable("dbo.Perfil");
            DropTable("dbo.Comentario");
            CreateIndex("dbo.Produto", "ClienteId");
            AddForeignKey("dbo.Produto", "ClienteId", "dbo.Cliente", "ClienteId");
        }
    }
}
