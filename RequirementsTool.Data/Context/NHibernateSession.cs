using System.Configuration;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Functional.Data.Nhibernate.SqlServer.Mapping;
using Functional.Data.Nhibernate.SqlServer.Util;
using Functional.Domain.Entities;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Functional.Data.Nhibernate.SqlServer.Context
{
    /// <summary>
    /// Fabrica de sessão do NHibernate
    /// </summary>
    public class NHibernateSession
    {
        /// <summary>
        /// Fábrica da sessão
        /// </summary>
        private static ISessionFactory _sessaoFactory;

        /// <summary>
        /// Retorna a sessão válida do nhibernate
        /// </summary>
        /// <returns>Retorna a sessão válida do NHibernate</returns>
        internal static ISession OpenSession()
        {
            return SessionFactory().OpenSession();
        }

        /// <summary>
        /// Fecha a sessão ativa
        /// </summary>
        public static void CloseSession()
        {
            _sessaoFactory.Close();
        }

        ///// <summary>
        ///// Cria uma fabrica
        ///// </summary>
        //public static void CreateFactory()
        //{
        //    if (_sessaoFactory == null)
        //    {
        //        var mapper = new ModelMapper();
        //        mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
        //        HbmMapping mapeamentoDominio = mapper.CompileMappingForAllExplicitlyAddedEntities();

        //        var configuration = new NHibernate.Cfg.Configuration();
        //        configuration.DataBaseIntegration(c =>
        //                                          {
        //                                              c.Dialect<NHibernate.Dialect.MsSql2008Dialect>();
        //                                              c.ConnectionString =
        //                                                  ConfigurationManager.ConnectionStrings["ConnectionString"]
        //                                                      .ConnectionString;
        //                                              // c.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        //                                              c.Driver<NHibernate.Driver.SqlClientDriver>();
        //                                          });

        //        configuration.AddMapping(mapeamentoDominio);

        //        var schema = new SchemaExport(configuration);
        //        schema.Execute(false, true, true);
        //        schema.Drop(false, true);
        //        schema.Create(false, true);
        //        //var excep = schema.Exceptions;

        //        _sessaoFactory = configuration.BuildSessionFactory();
        //    }
        //}

        public static void CreateFactory()
        {
            if (_sessaoFactory == null)
            {
                FluentConfiguration configuration = Fluently.Configure()
                                .Database(MsSqlConfiguration.MsSql2008
                                .ConnectionString(x => x.FromConnectionStringWithKey("ConnectionString")).ShowSql())
                                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                                .Mappings(x => x.FluentMappings
                                                .AddFromAssemblyOf<CasoDeUsoMap>()
                                                .Conventions.Add<StringPropertyConvention>()
                                                .Conventions.Add<CustomForeignKeyConvention>());

                _sessaoFactory = configuration.BuildSessionFactory();
            }
        }

        /// <summary>
        /// Cria uma nova fabrica
        /// </summary>
        /// <returns>Retorna a fabrica criada</returns>
        private static ISessionFactory SessionFactory()
        {
            CreateFactory();

            return _sessaoFactory;
        }
    }
}
