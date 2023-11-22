using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using RefitApi.Models;
using RefitApi.Services;

namespace RefitApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RefitApiController : ControllerBase
    {
        private readonly ICategoriaRefitService _categoriaRefitService;
        public RefitApiController(ICategoriaRefitService categoriaRefitService)
        {
            _categoriaRefitService = categoriaRefitService;
        }

        [HttpGet("categorias")]
        public async Task<IActionResult> GetTodasCategorias()
        {
            var result = await _categoriaRefitService.GetCategorias();

            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet("categorias/{id}")]
        public async Task<IActionResult> GetCategoriaPorId(int id)
        {
            var result = await _categoriaRefitService.GetCategoriaId(id);

            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("categorias")]
        public async Task<Categoria> CreateCategoria([FromBody] Categoria categoria)
        {
            var result = await _categoriaRefitService.AddCategoria(categoria);

            return result;
        }

        [HttpPut("categorias/{id}")]
        public async Task<ActionResult> UpdateCategoria(int id, [FromBody] Categoria categoria)
        {
            if (categoria.CategoriaId != id)
                return BadRequest("Ids não conferem");

            try
            {
                await _categoriaRefitService.UpdateCategoria(id, categoria);
                return Ok(categoria);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("categorias/{id}")]
        public async Task<IActionResult> RemoveCategoria(int id)
        {
            var result = await _categoriaRefitService.RemoveCategoria(id);

            if (result is null)
                return BadRequest();

            return Ok(result);
        }
    }
}