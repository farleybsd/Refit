using Microsoft.AspNetCore.Mvc;
using RefitApi.Models;
using RefitApi.Services;

namespace RefitApi.Controllers;

[Route("[controller]")]
[ApiController]
public class RefitApiController : ControllerBase
{
    private readonly ICategoriaRefitService _categoriaRefitService;

    public RefitApiController(ICategoriaRefitService categoriarefitService)
    {
        _categoriaRefitService = categoriarefitService;
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
