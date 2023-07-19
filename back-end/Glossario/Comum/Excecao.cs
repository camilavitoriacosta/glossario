namespace Glossario.Comum
{
    public class Excecao : Exception
    {
        public Excecao() : base("") { }

        public Excecao(string message) : base(message)
        {
        }

        public void QuandoEhStringVaziaOuNula(string campo)
        {
            if (string.IsNullOrWhiteSpace(campo))
                throw this;
        }
        public void Quando(bool condicao)
        {
            if (condicao)
                throw this;
        }
    }
}
