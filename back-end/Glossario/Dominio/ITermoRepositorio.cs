namespace Glossario.Dominio
{
    public interface ITermoRepositorio {
        List<Termo> ObterTodos();
        public void Salvar(Termo termo);
        public void Atualizar(Termo termo);
    }
}