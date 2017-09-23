using Mostremais.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mostremais.Infra.Repository.EntityFramework.EntityConfig
{
    class ProdutoSubcategoriaConfiguracao : EntityTypeConfiguration<ProdutoSubcategoria>
    {
        public ProdutoSubcategoriaConfiguracao()
        {
            HasKey(c => c.SubcategoriaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);


            this.ToTable("tb_empresa_subcategoria");
            this.Property(t => t.SubcategoriaId).HasColumnName("cdsubcategoria");
            this.Property(t => t.Nome).HasColumnName("nmcategoria");

        }
    }
}
