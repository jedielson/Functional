namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Functional.Domain.Entities.Model;
    class FluxoDeExcecaoMap : EntityTypeConfiguration<FluxoDeExcecao>
    {
        public FluxoDeExcecaoMap()
        {
            ToTable(nameof(FluxoDeExcecao));

            HasKey(x => x.FluxoId);
            Property(x => x.FluxoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.FluxoPrincipal)
                .WithMany(x => x.FluxosDeExcecao)
                .HasForeignKey(x => x.FluxoPrincipalId);

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
        }
    }
}
