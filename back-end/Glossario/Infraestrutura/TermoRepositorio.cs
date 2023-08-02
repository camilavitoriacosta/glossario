using Glossario.Dominio;
using System.Collections.Generic;
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

        public Termo ObterPor(string titulo)
        {
            using (var transacao = _session.BeginTransaction())
            try
            {
                return _session.Query<Termo>().Where(termo => termo.Titulo == titulo).SingleOrDefault();
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

        public Termo ObterPor(int id)
        {
            using (var transacao = _session.BeginTransaction())
                try
                {
                    return _session.Query<Termo>().Where(termo => termo.Id == id).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw;
                }
        }
    }
}
