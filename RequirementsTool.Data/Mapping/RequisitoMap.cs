using FluentNHibernate.Mapping;
using Functional.Domain.Entities;

namespace Functional.Data.Nhibernate.SqlServer.Mapping
{
    public class RequisitoMap : ClassMap<Requisito>
    {
        public RequisitoMap()
        {
            Table("Requisito");

            //Id(x => x.RequisitoId).GeneratedBy.Identity();
            Id(x => x.RequisitoId).GeneratedBy.Identity();

            Map(x => x.Codigo).Not.Nullable().Length(30);
            Map(x => x.Titulo).Not.Nullable().Length(100);
            Map(x => x.Descricao).Not.Nullable().Length(3000);
            Map(x => x.DataDeCriacao).Not.Nullable();
            Map(x => x.DataUltimaAlteracao).Not.Nullable();

            HasOne(x => x.Projeto).LazyLoad();

            HasManyToMany(x => x.CasosDeUso).LazyLoad();
        }
    }
}
