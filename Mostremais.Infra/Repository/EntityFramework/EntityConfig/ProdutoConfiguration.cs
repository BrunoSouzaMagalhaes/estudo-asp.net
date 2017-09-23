using Mostremais.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Mostremais.Infra.Repository.EntityFramework.EntityConfig
{
    class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(c => c.ProdutoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);


            this.ToTable("tb_empresa_produto");
            this.Property(t => t.ProdutoId).HasColumnName("cdproduto");
            this.Property(t => t.Nome).HasColumnName("nmproduto");
             
        }
    }
}
