namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Domain.Entities.Model;

    class ProjetoMap : EntityTypeConfiguration<Projeto>
    {
        public ProjetoMap()
        {
            this.HasKey(p => p.ProjetoId);
            Property(p => p.ProjetoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Codigo).IsRequired().HasMaxLength(10);

            this.Property(p => p.Nome).IsRequired().HasMaxLength(50);

            this.Property(p => p.DataDeCriacao).IsRequired();

            this.Property(p => p.DataUltimaAlteracao).IsRequired();

            this.Ignore(x => x.ValidationResult);
            this.Ignore(x => x.IsValid);
        }
    }
}
