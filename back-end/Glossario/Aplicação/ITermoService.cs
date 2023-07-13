using Glossario.Aplicação.Dtos;
using Glossario.Dominio;

namespace Glossario.Aplicação
{
    public interface ITermoService
    {
        public Termo cadastrar(TermoDto termo);
    }
}