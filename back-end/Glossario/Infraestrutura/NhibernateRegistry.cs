using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Glossario.Infraestrutura.Mapeamento;

namespace Projeto.Infra
{
    public static class NhibernateRegistry
    {
        public static void ObterSessionFactory(IServiceCollection services)
        {
            var connStr = @"Server=localhost;Database=glossario;User Id=sa;Password=123;";

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TermoMap>())
                .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", "web"))
                .BuildSessionFactory();

            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddSingleton(sessionFactory);
        }
    }
}