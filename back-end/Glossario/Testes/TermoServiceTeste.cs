using ExpectedObjects;
using Glossario.Aplicação;
using Glossario.Aplicação.Dtos;
using Glossario.Comum;
using Glossario.Dominio;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace Glossario.Testes
{
    [TestFixture]
    public class TermoServiceTeste
    {
        private ITermoRepositorio _termoRepositorio;
        private TermoService _termoService;
        private Termo _termo;
        private TermoDto _termoDto;

        [SetUp]
        public void SetUp()
        {
            _termoRepositorio = Substitute.For<ITermoRepositorio>();
            _termoService = new TermoService(_termoRepositorio);
            _termo = new Termo("Titulo", "Descricao", "Link")
            {
                Id = 0
            };
            _termoDto = new TermoDto()
            {
                Titulo = "Titulo",
                Descricao = "Descricao",
                Link = "Link"
            };
        }

        [Test]
        public void Deve_adicionar_um_termo()
        {
            const string titulo = "Termo";
            _termoDto.Titulo = titulo;
            _termo.Titulo = titulo;
            _termoRepositorio.ObterPor(titulo).ReturnsNull();

            var termoRetornado = _termoService.Cadastrar(_termoDto);

            _termo.ToExpectedObject().ShouldEqual(termoRetornado);
        }

        public static IEnumerable<TestCaseData> CasosDeTesteValidacaoCadastrarNovoTermo
        {
            get
            {
                yield return new TestCaseData(new TermoDto() { Titulo = "", Descricao = "Descricao", Link = "Link" }, MensagemDeExcecao.NomeObrigatorio);
                yield return new TestCaseData(new TermoDto() { Titulo = "Titulo", Descricao = "", Link = "Link" }, MensagemDeExcecao.DescricaoObrigatorio);
                yield return new TestCaseData(new TermoDto() { Titulo = "Titulo", Descricao = "Descricao", Link = "" }, MensagemDeExcecao.LinkObrigatorio);
            }
        }

        [TestCaseSource("CasosDeTesteValidacaoCadastrarNovoTermo")]
        public void Nao_deve_adicionar_um_termo_sem_campos_obrigatorios_testSource(TermoDto termoDto, string mensagem)
        {
            _termoRepositorio.ObterPor(termoDto.Titulo).ReturnsNull();

            TestDelegate acao = () => _termoService.Cadastrar(termoDto);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(mensagem, excecao.Message.Trim());
        }

        [TestCase("","Descricao", "Link", MensagemDeExcecao.NomeObrigatorio)]
        [TestCase("Titulo","", "Link", MensagemDeExcecao.DescricaoObrigatorio)]
        [TestCase("Titulo","Descricao", "", MensagemDeExcecao.LinkObrigatorio)]
        public void Nao_deve_adicionar_um_termo_sem_campos_obrigatorios(string titulo, string descricao, string link, string mensagem)
        {
            var termoDto = new TermoDto() { Titulo = titulo, Descricao = descricao, Link = link };
            _termoRepositorio.ObterPor(termoDto.Titulo).ReturnsNull();

            TestDelegate acao = () => _termoService.Cadastrar(termoDto);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(mensagem, excecao.Message.Trim());
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
            _termo.Titulo = "Termo 2";
            var termoRetornado = _termoService.Atualizar(_termo);

            _termo.ToExpectedObject().ShouldEqual(termoRetornado);
        }
    }
}
