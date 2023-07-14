namespace Glossario.Dominio
{
    public class Termo
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Link { get; set; }

        protected Termo()
        {
        }

        public Termo(string titulo, string descricao, string link)
        {
            Titulo = titulo;
            Descricao = descricao;
            Link = link;
        }
    }
}
