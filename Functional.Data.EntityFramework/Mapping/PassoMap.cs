namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Functional.Domain.Entities.Model;
    public class PassoMap : EntityTypeConfiguration<Passo>
    {
        public PassoMap()
        {
            HasKey(x => x.PassoId);
            Property(x => x.PassoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Fluxo)
                .WithMany(x => x.Passos)
                .HasForeignKey(x => x.FluxoId);

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);

        }
    }
}
