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

        public Termo cadastrar(TermoDto termoDto)
        {
            var termo = MapearDtoParaEntidade(termoDto);
            _termoRepositorio.Salvar(termo);
            return termo;
        }

        private Termo MapearDtoParaEntidade(TermoDto termoDto)
        {
            return new Termo
            {
                Titulo = termoDto.Titulo,
                Descricao = termoDto.Descricao,
                Link = termoDto.Link
            };
        }
    }
}
