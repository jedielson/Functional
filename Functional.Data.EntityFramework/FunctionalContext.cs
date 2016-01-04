namespace Functional.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Diagnostics;
    using System.Linq;

    using Config;

    using Functional.Domain.Entities.Model;

    using Mapping;

    public class FunctionalContext : BaseDbContext
    {
        static FunctionalContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public FunctionalContext()
            : base("ConnectionString")
        {
            Database.Log = s => Debug.Write(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                // ReSharper disable once PossibleNullReferenceException
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ProjetoMap());
            modelBuilder.Configurations.Add(new RequisitoMap());
            modelBuilder.Configurations.Add(new CasoDeUsoMap());
            modelBuilder.Configurations.Add(new FluxoPrincipalMap());
            modelBuilder.Configurations.Add(new FluxoAlternativoMap());
            modelBuilder.Configurations.Add(new FluxoDeExcecaoMap());
            modelBuilder.Configurations.Add(new PassoMap());
            modelBuilder.Configurations.Add(new RegraDeNegocioMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Valida a data de cadastro de uma entidade.
        /// Caso esteja sendo cadastrada, garante que a data atual será setada na data de criação do objeto.
        /// Caso esteja sendo editada, garante que a data de alteração será preenchida
        /// </summary>
        /// <returns>Um <see cref="int"/></returns>
        public override int SaveChanges()
        {
            var data = this.ChangeTracker.Entries();
            foreach (var entry in data.Where(entry => entry.Entity.GetType().GetProperty("DataDeCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCriacao").IsModified = false;
                }

                entry.Property("DataUltimaAlteracao").CurrentValue = DateTime.Now;
            }
            return base.SaveChanges();
        }

        #region DbSet

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Requisito> Requisitos { get; set; }

        public DbSet<CasoDeUso> CasosDeUso { get; set; }

        public DbSet<FluxoPrincipal> FluxosPrincipais { get; set; }

        public DbSet<FluxoAlternativo> FluxosAlternativos { get; set; }

        public DbSet<FluxoDeExcecao> FluxosDeExcecao { get; set; }

        public DbSet<Passo> Passos { get; set; }

        public DbSet<RegraDeNegocio> RegrasDeNegocio { get; set; }

        #endregion
    }
}
