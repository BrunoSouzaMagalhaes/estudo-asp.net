namespace Mostremais.Infra.Context
{
    using System.Data.Entity;
    using Mostremais.Domain.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions; 
    using System;
    using Mostremais.Infra.Repository.EntityFramework.EntityConfig;

    public partial class ApplicationContextDb : DbContext
    {
        public ApplicationContextDb()
            : base("name=ApplicationContextDb")
        {
             
        }

        DbSet<Empresa> Empresa { get; set; }
        DbSet<Cliente> Cliente { get; set; }
        DbSet<Produto> Produto { get; set; }
        DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
        DbSet<ProdutoSubcategoria> ProdutoSubcategoria { get; set; }
        DbSet<Venda> Venda { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoCategoriaConfiguracao());
            modelBuilder.Configurations.Add(new ProdutoSubcategoriaConfiguracao());
            modelBuilder.Configurations.Add(new VendaConfiguracao());

        }
         
    }
}

