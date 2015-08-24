using FluentNHibernate.Mapping;
using Functional.Domain.Entities;

namespace Functional.Data.Nhibernate.SqlServer.Mapping
{
    public class RegraDeNegocioMap : ClassMap<RegraDeNegocio>
    {
        public RegraDeNegocioMap()
        {
            Table("RegraDeNegocio");

            Id(x => x.RegraDeNegocioId).GeneratedBy.Identity();

            Map(x => x.Codigo).Not.Nullable().Length(30);
            Map(x => x.Descricao).Not.Nullable().Length(1000);
            Map(x => x.DataDeCriacao).Not.Nullable();
            Map(x => x.DataUltimaAlteracao).Not.Nullable();

            HasManyToMany(x => x.Passos).LazyLoad();
        }
    }
}
