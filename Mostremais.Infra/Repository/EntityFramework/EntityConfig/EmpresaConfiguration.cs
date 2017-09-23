using Mostremais.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Mostremais.Infra.Repository.EntityFramework.EntityConfig
{
    class EmpresaConfiguration: EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(c => c.EmpresaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Alias)
                .IsRequired()
                .HasMaxLength(150);
                          
            this.ToTable("tb_empresa");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId"); 
            this.Property(t => t.Nome).HasColumnName("nmfantasia");
            this.Property(t => t.Alias).HasColumnName("alias");

        }
    }
}
