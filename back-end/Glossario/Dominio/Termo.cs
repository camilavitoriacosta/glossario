using Glossario.Comum;

namespace Glossario.Dominio
{
    public class Termo
    {
        public virtual int Id { get; protected set; }
        public virtual string Titulo { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Link { get; protected set; }

        protected Termo()
        {
        }

        public Termo(string titulo, string descricao, string link)
        {
            VerificarCamposObrigatorios(titulo, descricao, link);
            Titulo = titulo;
            Descricao = descricao;
            Link = link;
        }

        private void VerificarCamposObrigatorios(string titulo, string descricao, string link)
        {
            ValidarTitulo(titulo);
            ValidarDescricao(descricao);
            ValidarLink(link);
        }

        private void ValidarLink(string link)
        {
            new Excecao(MensagemDeExcecao.LinkObrigatorio).QuandoEhStringVaziaOuNula(link);
        }

        private void ValidarDescricao(string descricao)
        {
            new Excecao(MensagemDeExcecao.DescricaoObrigatorio).QuandoEhStringVaziaOuNula(descricao);
        }

        private void ValidarTitulo(string titulo)
        {
            new Excecao(MensagemDeExcecao.TituloObrigatorio).QuandoEhStringVaziaOuNula(titulo);
        }

        public virtual void AlterarTitulo(string titulo)
        {
            ValidarTitulo(titulo);
            Titulo = titulo;
        }

        public virtual void AlterarDescricao(string descricao)
        {
            ValidarDescricao(descricao);
            Descricao = descricao;
        }

        public virtual void AlterarLink(string link)
        {
            ValidarLink(link);
            Link = link;
        }
    }
}
