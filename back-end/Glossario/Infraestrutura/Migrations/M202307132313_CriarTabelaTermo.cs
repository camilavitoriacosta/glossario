using FluentMigrator;

namespace Glossario.Infraestrutura.Migrations
{
    [Migration(202307132313)]
    public class M202307132313_CriarTabelaTermo : Migration
    {
        private readonly string novaTabela = "Termo";

        public override void Up()
        {
            Create.Table(novaTabela)
                .WithColumn("Id").AsInt32().Identity()
                .WithColumn("Titulo").AsString()
                .WithColumn("Descricao").AsString()
                .WithColumn("Link").AsString();
        }

        public override void Down() {
            Delete.Table(novaTabela);
        }
    }
}
