using FluentNHibernate.Mapping;
using Functional.Domain.Entities;

namespace Functional.Data.Nhibernate.SqlServer.Mapping
{
    public class CasoDeUsoMap : ClassMap<CasoDeUso>
    {
        public CasoDeUsoMap()
        {
            Table("CasoDeUso");
            
            Id(x => x.CasoDeUsoId).GeneratedBy.Identity();

            Map(x => x.Codigo).Not.Nullable().Length(30);
            Map(x => x.Titulo).Not.Nullable().Length(200);

            References(x => x.FluxoPrincipal).Not.Nullable();

            HasMany(x => x.FluxosAlternativos).KeyNullable();
            HasMany(x => x.FluxosExcecao).KeyNullable();

            HasManyToMany(x => x.Requisitos);
        }
    }
}
