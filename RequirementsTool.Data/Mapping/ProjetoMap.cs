using FluentNHibernate.Mapping;
using Functional.Domain.Entities;

namespace Functional.Data.Nhibernate.SqlServer.Mapping
{
    public class ProjetoMap : ClassMap<Projeto>
    {
        public ProjetoMap()
        {
            Table("Projeto");

            Id(x => x.ProjetoId).GeneratedBy.Identity();

            Map(x => x.Codigo).Not.Nullable().Length(30);
            Map(x => x.Nome).Not.Nullable().Length(50);
            Map(x => x.DataDeCriacao).Not.Nullable();
            Map(x => x.DataUltimaAlteracao).Not.Nullable();

            HasMany(x => x.Requisitos).LazyLoad();
        }
    }
}
