using Glossario.Aplicação.Dtos;
using Glossario.Dominio;

namespace Glossario.Aplicação
{
    public interface ITermoService
    {
        public Termo Cadastrar(TermoDto termo);
        public Termo Atualizar(TermoParaAtualizarDto termo);
        public List<Termo> ObterTodosTermos();
    }
}