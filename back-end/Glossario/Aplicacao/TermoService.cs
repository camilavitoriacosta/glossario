using Glossario.Aplicacao.Dtos;
using Glossario.Comum;
using Glossario.Dominio;
using Glossario.Infraestrutura;

namespace Glossario.Aplicacao
{
    public class TermoService : ITermoService
    {
        private readonly ITermoRepositorio _termoRepositorio;

        public TermoService(ITermoRepositorio termoRepositorio)
        {
            _termoRepositorio = termoRepositorio;
        }

        public Termo Cadastrar(TermoDto termoDto)
        {
            ValidarSeTermoExiste(termoDto.Titulo);
            var termo = MapearDtoParaEntidade(termoDto);
            _termoRepositorio.Salvar(termo);
            return termo;
        }

        private void ValidarSeTermoExiste(string titulo)
        {
            new Excecao(MensagemDeExcecao.TermoJaExiste).Quando(_termoRepositorio.ObterPor(titulo) != null);
        }

        public Termo Atualizar(TermoParaAtualizarDto termoParaAtualizarDto)
        {
            Termo termo = _termoRepositorio.ObterPor(termoParaAtualizarDto.Id);
            ValidarSeTermoEhNulo(termo);
            termo.AlterarTitulo(termoParaAtualizarDto.Titulo);
            termo.AlterarDescricao(termoParaAtualizarDto.Descricao);
            termo.AlterarLink(termoParaAtualizarDto.Link);
            _termoRepositorio.Atualizar(termo);
            return termo;
        }

        private void ValidarSeTermoEhNulo(Termo termo)
        {
            new Excecao(MensagemDeExcecao.TermoNaoExiste).Quando(termo == null);
        }

        public List<Termo> ObterTodosTermos()
        {
            return _termoRepositorio.ObterTodos();
        }

        private Termo MapearDtoParaEntidade(TermoDto termoDto)
        {
            return new Termo(termoDto.Titulo, termoDto.Descricao, termoDto.Link);
        }
    }
}
