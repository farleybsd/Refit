using Refit;
using RefitApi.Models;

namespace RefitApi.Services
{
    public interface ITipoUnidadesSaude
    {
        [Get("/cnes/tipounidades")]
        Task<TiposUnidade> GetTiposUnidade();
    }
}
