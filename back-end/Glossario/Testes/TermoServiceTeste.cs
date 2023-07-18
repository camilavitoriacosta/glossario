using ExpectedObjects;
using Glossario.Aplicação;
using Glossario.Aplicação.Dtos;
using Glossario.Dominio;
using NSubstitute;
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
            var termoRetornado = _termoService.Cadastrar(_termoDto);

            _termo.ToExpectedObject().ShouldEqual(termoRetornado);
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
