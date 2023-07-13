using Glossario.Aplicação.Dtos;
using Glossario.Dominio;
using Glossario.Infraestrutura;

namespace Glossario.Aplicação
{
    public class TermoService : ITermoService
    {
        private readonly TermoRepositorio _termoRepositorio;

        public Termo cadastrar(TermoDto termo)
        {
            _termoRepositorio.Salvar(termo);
            return termo;
        }
    }
}
