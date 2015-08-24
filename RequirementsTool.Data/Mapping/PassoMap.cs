using FluentNHibernate.Mapping;
using Functional.Domain.Entities;

namespace Functional.Data.Nhibernate.SqlServer.Mapping
{
    public class PassoMap : ClassMap<Passo>
    {
        public PassoMap()
        {
            Table("Passo");

            Id(x => x.PassoId).GeneratedBy.Identity();
            
            Map(x => x.Sequencia).Not.Nullable();
            Map(x => x.Descricao).Not.Nullable().Length(500);

            References(x => x.Fluxo).Not.Nullable();

            HasManyToMany(x => x.RegrasDeNegocio).LazyLoad();
        }
    }
}
