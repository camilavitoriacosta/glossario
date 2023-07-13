using FluentMigrator.Runner;
using System.Reflection;

namespace Glossario.Infraestrutura
{
    public static class GerenciadorMigracao
    {
        public static void ConfigurarMigracao()
        {
            var connStr = @"Server=localhost;Database=Glossario;User Id=sa;Password=PapelZero.123;";

            var serviceProvider = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer2012()
                    .WithGlobalConnectionString(connStr)
                    .ScanIn(Assembly.LoadFrom(@"bin\Debug\net6.0\Glossario.dll")).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider();

            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();

        }
    }
}
