using Glossario.Aplicação;
using Glossario.Aplicação.Dtos;
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
            return Ok();
        }

        [HttpPost]
        public ActionResult AdicionarTermo([FromBody] TermoDto termodto)
        {
            var termo = _termoService.cadastrar(termodto);
            return Ok(termo);
        }
    }
}
