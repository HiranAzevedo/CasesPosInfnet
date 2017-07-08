namespace Infnet.SIFISCON.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoDeInfracao",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Gravidade = c.Int(nullable: false),
                        Atenuante = c.Boolean(nullable: false),
                        Agravante = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Processo", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Processo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RelatoFiscalizacao = c.String(),
                        DataRelato = c.DateTime(nullable: false),
                        FiscalResponsavel = c.String(),
                        FornecedorId = c.Int(nullable: false),
                        AutoDeInfracaoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId, cascadeDelete: true)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(),
                        RazaoSocial = c.String(),
                        InscricaoMunicipal = c.String(),
                        ReceitaBruta = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Municipio = c.String(),
                        Cep = c.String(),
                        UF = c.String(),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId, cascadeDelete: true)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Marca = c.String(),
                        Estoque = c.String(),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId, cascadeDelete: true)
                .Index(t => t.FornecedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutoDeInfracao", "Id", "dbo.Processo");
            DropForeignKey("dbo.Processo", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Produto", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Endereco", "FornecedorId", "dbo.Fornecedor");
            DropIndex("dbo.Produto", new[] { "FornecedorId" });
            DropIndex("dbo.Endereco", new[] { "FornecedorId" });
            DropIndex("dbo.Processo", new[] { "FornecedorId" });
            DropIndex("dbo.AutoDeInfracao", new[] { "Id" });
            DropTable("dbo.Produto");
            DropTable("dbo.Endereco");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Processo");
            DropTable("dbo.AutoDeInfracao");
        }
    }
}
