using Glossario.Dominio;
using ISession = NHibernate.ISession;

namespace Glossario.Infraestrutura
{
    public class TermoRepositorio :ITermoRepositorio
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
