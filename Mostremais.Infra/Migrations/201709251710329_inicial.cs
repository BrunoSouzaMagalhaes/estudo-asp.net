namespace Mostremais.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_empresa_cliente",
                c => new
                    {
                        cdcliente = c.Int(nullable: false, identity: true),
                        nmcliente = c.String(nullable: false, maxLength: 150, unicode: false),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cdcliente)
                .ForeignKey("dbo.tb_empresa", t => t.EmpresaId)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.tb_empresa",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        nmfantasia = c.String(nullable: false, maxLength: 150, unicode: false),
                        alias = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.EmpresaId);
            
            CreateTable(
                "dbo.tb_empresa_produto",
                c => new
                    {
                        cdproduto = c.Int(nullable: false, identity: true),
                        nmproduto = c.String(nullable: false, maxLength: 150, unicode: false),
                        Preco = c.Single(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        SubcategoriaId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cdproduto)
                .ForeignKey("dbo.tb_empresa", t => t.EmpresaId)
                .ForeignKey("dbo.tb_empresa_categoria", t => t.CategoriaId)
                .ForeignKey("dbo.tb_empresa_subcategoria", t => t.SubcategoriaId)
                .Index(t => t.CategoriaId)
                .Index(t => t.SubcategoriaId)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.tb_empresa_categoria",
                c => new
                    {
                        cdcategoria = c.Int(nullable: false, identity: true),
                        nmcategoria = c.String(nullable: false, maxLength: 150, unicode: false),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cdcategoria)
                .ForeignKey("dbo.tb_empresa", t => t.EmpresaId)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.tb_empresa_subcategoria",
                c => new
                    {
                        cdsubcategoria = c.Int(nullable: false, identity: true),
                        nmcategoria = c.String(nullable: false, maxLength: 150, unicode: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cdsubcategoria)
                .ForeignKey("dbo.tb_empresa_categoria", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.tb_empresa_vendas",
                c => new
                    {
                        cdvenda = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cdvenda)
                .ForeignKey("dbo.tb_empresa_cliente", t => t.ClienteId)
                .ForeignKey("dbo.tb_empresa", t => t.EmpresaId)
                .Index(t => t.ClienteId)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.VendaProduto",
                c => new
                    {
                        Venda_VendaId = c.Int(nullable: false),
                        Produto_ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Venda_VendaId, t.Produto_ProdutoId })
                .ForeignKey("dbo.tb_empresa_vendas", t => t.Venda_VendaId)
                .ForeignKey("dbo.tb_empresa_produto", t => t.Produto_ProdutoId)
                .Index(t => t.Venda_VendaId)
                .Index(t => t.Produto_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaProduto", "Produto_ProdutoId", "dbo.tb_empresa_produto");
            DropForeignKey("dbo.VendaProduto", "Venda_VendaId", "dbo.tb_empresa_vendas");
            DropForeignKey("dbo.tb_empresa_vendas", "EmpresaId", "dbo.tb_empresa");
            DropForeignKey("dbo.tb_empresa_vendas", "ClienteId", "dbo.tb_empresa_cliente");
            DropForeignKey("dbo.tb_empresa_produto", "SubcategoriaId", "dbo.tb_empresa_subcategoria");
            DropForeignKey("dbo.tb_empresa_subcategoria", "CategoriaId", "dbo.tb_empresa_categoria");
            DropForeignKey("dbo.tb_empresa_produto", "CategoriaId", "dbo.tb_empresa_categoria");
            DropForeignKey("dbo.tb_empresa_categoria", "EmpresaId", "dbo.tb_empresa");
            DropForeignKey("dbo.tb_empresa_produto", "EmpresaId", "dbo.tb_empresa");
            DropForeignKey("dbo.tb_empresa_cliente", "EmpresaId", "dbo.tb_empresa");
            DropIndex("dbo.VendaProduto", new[] { "Produto_ProdutoId" });
            DropIndex("dbo.VendaProduto", new[] { "Venda_VendaId" });
            DropIndex("dbo.tb_empresa_vendas", new[] { "EmpresaId" });
            DropIndex("dbo.tb_empresa_vendas", new[] { "ClienteId" });
            DropIndex("dbo.tb_empresa_subcategoria", new[] { "CategoriaId" });
            DropIndex("dbo.tb_empresa_categoria", new[] { "EmpresaId" });
            DropIndex("dbo.tb_empresa_produto", new[] { "EmpresaId" });
            DropIndex("dbo.tb_empresa_produto", new[] { "SubcategoriaId" });
            DropIndex("dbo.tb_empresa_produto", new[] { "CategoriaId" });
            DropIndex("dbo.tb_empresa_cliente", new[] { "EmpresaId" });
            DropTable("dbo.VendaProduto");
            DropTable("dbo.tb_empresa_vendas");
            DropTable("dbo.tb_empresa_subcategoria");
            DropTable("dbo.tb_empresa_categoria");
            DropTable("dbo.tb_empresa_produto");
            DropTable("dbo.tb_empresa");
            DropTable("dbo.tb_empresa_cliente");
        }
    }
}
