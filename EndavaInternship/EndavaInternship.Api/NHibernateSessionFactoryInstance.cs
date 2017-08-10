using EndavaInternship.Api.Dal;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace EndavaInternship.Api
{
    public class NHibernateSessionFactoryInstance
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory => _sessionFactory ?? (_sessionFactory = Create());

        private static ISessionFactory Create()
        {
            //var sessionFactory = Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2005
            //        .ConnectionString("connection string")
            //        .ShowSql())
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BankDetailsEntity>())
            //    .BuildSessionFactory();

            var sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile("D:\\file.db")
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BankDetailsEntity>())
                //.ExposeConfiguration(c => new SchemaExport(c)
                //    .Create(false, true))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}