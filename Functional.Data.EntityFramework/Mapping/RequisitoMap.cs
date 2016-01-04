namespace Functional.Data.Context.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Functional.Domain.Entities.Model;
    public class RequisitoMap : EntityTypeConfiguration<Requisito>
    {
        public RequisitoMap()
        {
            HasKey(r => r.RequisitoId);
            Property(r => r.RequisitoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Descricao).HasMaxLength(500);

            HasRequired(r => r.Projeto)
                .WithMany(x => x.Requisitos)
                .HasForeignKey(r => r.ProjetoId);

            HasMany(r => r.CasosDeUso)
                .WithMany(c => c.Requisitos).Map(
                    x =>
                        {
                            x.MapLeftKey("CasoDeUsoId");
                            x.MapRightKey("RequisitoId");
                        });

            Ignore(r => r.ValidationResult);
            Ignore(r => r.IsValid);
        }
    }
}
