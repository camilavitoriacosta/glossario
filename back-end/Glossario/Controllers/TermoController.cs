using Glossario.Aplicação;
using Glossario.Aplicação.Dtos;
using Glossario.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Glossario.Controllers
{
    [Route("api/termos")]
    [ApiController]
    public class TermoController : ControllerBase
    {
        private readonly ITermoService _termoService;
        public TermoController(ITermoService termoService) { 
            _termoService = termoService;
        }

        [HttpGet]
        public ActionResult ObterTermos()
        {
            var termos = _termoService.ObterTodosTermos();
            return Ok(termos);
        }

        [HttpPost]
        public ActionResult AdicionarTermo([FromBody] TermoDto termodto)
        {
            var termo = _termoService.Cadastrar(termodto);
            return Ok(termo);
        }
        
        [HttpPut]
        public ActionResult AtualizarTermo([FromBody] Termo termo)
        {
            _termoService.Atualizar(termo);
            return Ok(termo);
        }
    }
}
