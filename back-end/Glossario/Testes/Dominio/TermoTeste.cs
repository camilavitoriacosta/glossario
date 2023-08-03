using Glossario.Aplicacao.Dtos;
using Glossario.Comum;
using Glossario.Dominio;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;

namespace Glossario.Testes.Dominio
{
    [TestFixture]
    public class TermoTeste
    {
        private Termo _termo;

        [SetUp]
        public void SetUp()
        {
            _termo = new Termo("Titulo", "Descricao", "Link");
        }

        [TestCase("", "Descricao", "Link", MensagemDeExcecao.TituloObrigatorio)]
        [TestCase("Titulo", "", "Link", MensagemDeExcecao.DescricaoObrigatorio)]
        [TestCase("Titulo", "Descricao", "", MensagemDeExcecao.LinkObrigatorio)]
        public void Nao_deve_adicionar_um_termo_sem_campos_obrigatorios(string titulo, string descricao, string link, string mensagem)
        {

            TestDelegate acao = () => new Termo(titulo, descricao, link);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(mensagem, excecao.Message.Trim());
        }

        [Test]
        public void Deve_alterar_o_titulo_de_um_termo()
        {
            var titulo = "Novo titulo";

            _termo.AlterarTitulo(titulo);

            Assert.AreEqual(titulo, _termo.Titulo);
        }

        [TestCase("")]
        [TestCase(null)]
        [Test]
        public void Deve_lancar_excecao_de_titulo_obrigatorio(string titulo)
        {
            TestDelegate acao = () => _termo.AlterarTitulo(titulo);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(MensagemDeExcecao.TituloObrigatorio, excecao.Message.Trim());
        }

        [Test]
        public void Deve_alterar_a_descricao_de_um_termo()
        {
            var descricao = "Nova Descricao";

            _termo.AlterarDescricao(descricao);

            Assert.AreEqual(descricao, _termo.Descricao);
        }

        [TestCase("")]
        [TestCase(null)]
        [Test]
        public void Deve_lancar_excecao_de_descricao_obrigatoria(string descricao)
        {
            TestDelegate acao = () => _termo.AlterarDescricao(descricao);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(MensagemDeExcecao.DescricaoObrigatorio, excecao.Message.Trim());
        }
        
        [Test]
        public void Deve_alterar_o_link_de_um_termo()
        {
            var link = "Novo link";

            _termo.AlterarLink(link);

            Assert.AreEqual(link, _termo.Link);
        }

        [TestCase("")]
        [TestCase(null)]
        [Test]
        public void Deve_lancar_excecao_de_link_obrigatorio(string link)
        {
            TestDelegate acao = () => _termo.AlterarLink(link);

            var excecao = Assert.Throws<Excecao>(acao);
            Assert.AreEqual(MensagemDeExcecao.LinkObrigatorio, excecao.Message.Trim());
        }
    }
}
