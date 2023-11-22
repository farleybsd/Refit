using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using RefitApi.Models;
using RefitApi.Services;

namespace RefitApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiposUnidadeController : ControllerBase
    {
        private readonly ITipoUnidadesSaude _tipoUnidadesSaude;
        public TiposUnidadeController(ITipoUnidadesSaude tipoUnidadesSaude)
        {
            _tipoUnidadesSaude = tipoUnidadesSaude;
        }

        [HttpGet("TiposUnidade")]
        public async Task<IActionResult> GetTiposUnidade()
        {
            var result = await _tipoUnidadesSaude.GetTiposUnidade();

            if (result is null)
                return BadRequest();

            return Ok(result);
        }
    }
}