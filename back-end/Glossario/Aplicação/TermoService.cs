using Glossario.Aplicação.Dtos;
using Glossario.Comum;
using Glossario.Dominio;

namespace Glossario.Aplicação
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
            var termo = MapearDtoParaEntidade(termoDto);
            VerificarCamposObrigatorios(termo);
            VerificarSeTermoJaExiste(termo);
            _termoRepositorio.Salvar(termo);
            return termo;
        }

        private void VerificarSeTermoJaExiste(Termo termo)
        {
            bool condicao = _termoRepositorio.ObterPor(termo.Titulo) != null;
            new Excecao(MensagemDeExcecao.TermoJaExiste).Quando(condicao);
        }

        private void VerificarCamposObrigatorios(Termo termo)
        {
            new Excecao(MensagemDeExcecao.NomeObrigatorio).QuandoEhStringVaziaOuNula(termo.Titulo);
            new Excecao(MensagemDeExcecao.DescricaoObrigatorio).QuandoEhStringVaziaOuNula(termo.Descricao);
            new Excecao(MensagemDeExcecao.LinkObrigatorio).QuandoEhStringVaziaOuNula(termo.Link);
        }

        public Termo Atualizar(Termo termo)
        {
            VerificarCamposObrigatorios(termo);
            _termoRepositorio.Atualizar(termo);
            return termo;
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
