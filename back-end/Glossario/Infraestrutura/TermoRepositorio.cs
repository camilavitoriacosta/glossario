using Glossario.Dominio;

namespace Glossario.Infraestrutura
{
    public class TermoRepositorio
    {
        private readonly ISession _session;

        public TermoRepositorio(ISession session) { 
            _session = session;
        }

        public void Salvar(Termo termo)
        {
            using (var transacao = _session.BeginTransaction())
                try
                {
                    _session.Save(termo);
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw;
                }
        }
    }
}
