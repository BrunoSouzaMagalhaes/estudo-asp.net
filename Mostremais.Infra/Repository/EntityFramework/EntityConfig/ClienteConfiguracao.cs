using Mostremais.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Mostremais.Infra.Repository.EntityFramework.EntityConfig
{
    class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
              

            this.ToTable("tb_empresa_cliente");
            this.Property(t => t.ClienteId).HasColumnName("cdcliente");
            this.Property(t => t.Nome).HasColumnName("nmcliente"); 
             
        }
    }
}
