using FluentNHibernate.Mapping;
using Glossario.Dominio;

namespace Glossario.Infraestrutura.Mapeamento
{
    public class TermoMap: ClassMap<Termo>
    {
        public TermoMap() {
            Id(termo => termo.Id).GeneratedBy.Identity();
            Map(termo => termo.Titulo);
            Map(termo => termo.Descricao);
            Map(termo => termo.Link);
        }
    }
}
