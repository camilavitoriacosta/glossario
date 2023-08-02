using ExpectedObjects;
using Glossario.Aplicação;
using Glossario.Aplicação.Dtos;
using Glossario.Comum;
using Glossario.Dominio;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System.Diagnostics;

namespace Glossario.Testes.Aplicacao
{
    [TestFixture]
    public class TermoServiceTeste
    {
        private ITermoRepositorio _termoRepositorio;
        private TermoService _termoService;
        private Termo _termo;
        private TermoDto _termoDto;
        private TermoParaAtualizarDto _termoParaAtualizarDto;

        [SetUp]
        public void SetUp()
        {
            _termoRepositorio = Substitute.For<ITermoRepositorio>();
            _termoService = new TermoService(_termoRepositorio);
            _termo = new Termo("Titulo", "Descricao", "Link");

            _termoDto = new TermoDto()
            {
                Titulo = "Titulo",
                Descricao = "Descricao",
                Link = "Link"
            };
            
            _termoParaAtualizarDto = new TermoParaAtualizarDto()
            {
                Titulo = "Titulo",
                Descricao = "Descricao",
                Link = "Link",
                Id = 0
            };
        }

        [Test]
        public void Deve_adicionar_um_termo()
        {
            const string titulo = "Termo";
            _termoDto.Titulo = titulo;
            _termo.AlterarTitulo(titulo);
            _termoRepositorio.ObterPor(titulo).ReturnsNull();

            var termoRetornado = _termoService.Cadastrar(_termoDto);

            _termo.ToExpectedObject().ShouldEqual(termoRetornado);
        }

        [Test]
        public void Nao_deve_adicionar_um_termo_que_ja_existe()
        {
            _termoRepositorio.ObterPor(_termoDto.Titulo).Returns(_termo);

            TestDelegate acao = () => _termoService.Cadastrar(_termoDto);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(MensagemDeExcecao.TermoJaExiste, excecao.Message.Trim());
        }

        [Test]
        public void Deve_obter_todos_os_termos()
        {
            var termos = new List<Termo>()
            {
                _termo
            };
            _termoRepositorio.ObterTodos().Returns(termos);

            var termosRetornados = _termoService.ObterTodosTermos();

            termos.ToExpectedObject().ShouldEqual(termosRetornados);
        }

        [Test]
        public void Deve_atualizar_um_termo()
        {
            _termoParaAtualizarDto.Titulo = "Termo 2";
            _termoRepositorio.ObterPor(_termoParaAtualizarDto.Id).Returns(_termo);
            
            var termoRetornado = _termoService.Atualizar(_termoParaAtualizarDto);

            _termo.ToExpectedObject().ShouldEqual(termoRetornado);
        }

        [Test]
        public void Nao_deve_atualizar_um_termo_que_nao_existe()
        {
            _termoRepositorio.ObterPor(_termoDto.Titulo).ReturnsNull();

            TestDelegate acao = () => _termoService.Atualizar(_termoParaAtualizarDto);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(MensagemDeExcecao.TermoNaoExiste, excecao.Message.Trim());
        }
    }
}
