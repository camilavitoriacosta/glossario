using Glossario.Dominio;
using ISession = NHibernate.ISession;

namespace Glossario.Infraestrutura
{
    public class TermoRepositorio : ITermoRepositorio
    {
        private readonly ISession _session;

        public TermoRepositorio(ISession session) { 
            _session = session;
        }

        public void Atualizar(Termo termo)
        {
            using var transacao = _session.BeginTransaction();
            try
            {
                _session.Update(termo);
                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                throw;
            }
        }

        public List<Termo> ObterTodos()
        {
            using (var transacao = _session.BeginTransaction())
                try
                {
                    var termos = _session.Query<Termo>().ToList();
                    transacao.Commit();
                    return termos;
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw;
                }
        }

        public void Salvar(Termo termo)
        {
            using var transacao = _session.BeginTransaction();
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
