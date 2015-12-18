namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Functional.Domain.Entities.Model;
    public class FluxoPrincipalMap : EntityTypeConfiguration<FluxoPrincipal>
    {
        public FluxoPrincipalMap()
        {

            ToTable(nameof(FluxoPrincipal));

            HasKey(x => x.FluxoId);
            Property(x => x.FluxoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(f => f.CasoDeUso).WithOptional(c => c.FluxoPrincipal);

            Ignore(f => f.ValidationResult);
            Ignore(f => f.IsValid);
        }
    }
}
