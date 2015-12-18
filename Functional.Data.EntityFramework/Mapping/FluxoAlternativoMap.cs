namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Functional.Domain.Entities.Model;
    public class FluxoAlternativoMap : EntityTypeConfiguration<FluxoAlternativo>
    {
        public FluxoAlternativoMap()
        {
            ToTable(nameof(FluxoAlternativo));

            HasKey(x => x.FluxoId);
            Property(x => x.FluxoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.FluxoPrincipal)
                .WithMany(x => x.FluxosAlternativos)
                .HasForeignKey(x => x.FluxoPrincipalId);

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
        }
    }
}
