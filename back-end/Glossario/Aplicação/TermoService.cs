using Glossario.Aplicação.Dtos;
using Glossario.Dominio;

namespace Glossario.Aplicação
{
    public class TermoService : ITermoService
    {
        private readonly ITermoRepositorio _termoRepositorio;

        public TermoService(ITermoRepositorio termoRepositorio)
        {
            _termoRepositorio = termoRepositorio;
        }

        public Termo Cadastrar(TermoDto termoDto)
        {
            var termo = MapearDtoParaEntidade(termoDto);
            _termoRepositorio.Salvar(termo);
            return termo;
        }
        
        public Termo Atualizar(Termo termo)
        {
            _termoRepositorio.Atualizar(termo);
            return termo;
        }

        public List<Termo> ObterTodosTermos()
        {
            return _termoRepositorio.ObterTodos();
        }

        private Termo MapearDtoParaEntidade(TermoDto termoDto)
        {
            return new Termo(termoDto.Titulo, termoDto.Descricao, termoDto.Link);
        }
    }
}
