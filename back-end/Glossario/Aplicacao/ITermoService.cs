using Glossario.Aplicacao.Dtos;
using Glossario.Dominio;

namespace Glossario.Aplicacao
{
    public interface ITermoService
    {
        public Termo Cadastrar(TermoDto termo);
        public Termo Atualizar(TermoParaAtualizarDto termo);
        public List<Termo> ObterTodosTermos();
    }
}