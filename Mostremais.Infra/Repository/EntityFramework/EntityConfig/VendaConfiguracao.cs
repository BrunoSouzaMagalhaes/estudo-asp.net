using Mostremais.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Mostremais.Infra.Repository.EntityFramework.EntityConfig
{
    class VendaConfiguracao : EntityTypeConfiguration<Venda>
    {
        public VendaConfiguracao()
        {
            HasKey(c => c.VendaId); 

            this.ToTable("tb_empresa_vendas");
            this.Property(t => t.VendaId).HasColumnName("cdvenda");
             
        }
    }
}
