using Refit;
using RefitApi.Models;

namespace RefitApi.Services
{
    public interface ICategoriaRefitService
    {
        [Get("/api/1/categorias")]
        Task<IEnumerable<Categoria>> GetCategorias();

        [Get("/api/1/categorias/{id}")]
        Task<Categoria> GetCategoriaId(int id);

        [Post("/api/1/categorias")]
        Task<Categoria> AddCategoria(Categoria categoria);

        [Put("/api/1/categorias/{id}")]
        Task UpdateCategoria(int id, [Body] Categoria categoria);

        [Delete("/api/1/categorias/{id}")]
        Task<Categoria> RemoveCategoria(int id);
    }
}
