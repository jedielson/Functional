namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Functional.Domain.Entities.Model;

    public class CasoDeUsoMap : EntityTypeConfiguration<CasoDeUso>
    {
        public CasoDeUsoMap()
        {
            HasKey(c => c.CasoDeUsoId);
            Property(c => c.CasoDeUsoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(c => c.FluxoPrincipal)
                .WithRequired(f => f.CasoDeUso);

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
        }
    }
}
