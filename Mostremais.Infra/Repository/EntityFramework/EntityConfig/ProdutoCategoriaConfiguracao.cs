using Mostremais.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Mostremais.Infra.Repository.EntityFramework.EntityConfig
{
    class ProdutoCategoriaConfiguracao : EntityTypeConfiguration<ProdutoCategoria>
    {
        public ProdutoCategoriaConfiguracao()
        {
            HasKey(c => c.CategoriaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
             
            this.ToTable("tb_empresa_categoria");
            this.Property(t => t.CategoriaId).HasColumnName("cdcategoria");
            this.Property(t => t.Nome).HasColumnName("nmcategoria"); 
            
        }
    }
}
