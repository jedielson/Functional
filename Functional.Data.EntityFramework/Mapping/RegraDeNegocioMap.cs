namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Functional.Domain.Entities.Model;
    public class RegraDeNegocioMap : EntityTypeConfiguration<RegraDeNegocio>
    {
        public RegraDeNegocioMap()
        {
            HasKey(x => x.RegraDeNegocioId);
            Property(x => x.RegraDeNegocioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            HasMany(x => x.Passos)
                .WithMany(x => x.RegrasDeNegocio).Map(
                    x =>
                        {
                            x.MapLeftKey("RegraDeNegocioId");
                            x.MapRightKey("PassoId");
                        }
                );

            Ignore(x => x.ValidationResult);
            Ignore(x => x.IsValid);
        }
    }
}
