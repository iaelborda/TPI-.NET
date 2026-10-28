using DTOs;

namespace Application.Services
{
    public interface IReporteService
    {
        Task<List<ReporteAlquileresDTO>> ObtenerReporteAlquileresAsync(ReporteAlquileresCriteriaDTO criteria);
        Task<List<ReporteRankingBicicletaDTO>> ObtenerTop10BicicletasAnioAsync(int anio);
    }
}
