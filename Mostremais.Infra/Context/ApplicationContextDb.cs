namespace Mostremais.Infra.Context
{
    using System.Data.Entity;
    using Mostremais.Domain.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions; 
    using System;
    using Mostremais.Infra.Repository.EntityFramework.EntityConfig;
    using System.Data.Entity.Validation;

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

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}

