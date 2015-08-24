using FluentNHibernate.Mapping;
using Functional.Domain.Entities;

namespace Functional.Data.Nhibernate.SqlServer.Mapping
{
    public class FluxoMap : ClassMap<Fluxo>
    {
        public FluxoMap()
        {
            Table("Fluxo");

            Id(x => x.FluxoId).GeneratedBy.Identity();

            Map(x => x.Tipo).Not.Nullable();
            Map(x => x.Titulo).Not.Nullable().Length(100);

            HasMany(x => x.Passos).LazyLoad();
        }
    }
}
