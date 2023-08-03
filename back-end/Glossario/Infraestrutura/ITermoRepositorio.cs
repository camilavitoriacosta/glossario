using Glossario.Dominio;

namespace Glossario.Infraestrutura
{
    public interface ITermoRepositorio
    {
        List<Termo> ObterTodos();
        public void Salvar(Termo termo);
        public void Atualizar(Termo termo);
        Termo ObterPor(string titulo);
        Termo ObterPor(int id);
    }
}