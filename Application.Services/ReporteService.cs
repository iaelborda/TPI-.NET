using Data;
using DTOs;

namespace Application.Services
{
    public class ReporteService : IReporteService
    {
        private readonly AlquilerRepository _alquilerRepository;
        private readonly ISucursalRepository _sucursalRepository;

        public ReporteService(AlquilerRepository alquilerRepository, ISucursalRepository sucursalRepository)
        {
            _alquilerRepository = alquilerRepository;
            _sucursalRepository = sucursalRepository;
        }

        public async Task<List<ReporteAlquileresDTO>> ObtenerReporteAlquileresAsync(ReporteAlquileresCriteriaDTO criteria)
        {
            if (criteria.FechaDesde.Date > criteria.FechaHasta.Date)
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            
            int? sucursalId = criteria.SucursalId > 0 ? criteria.SucursalId : null;

            var alquileres = await _alquilerRepository.GetReporteAlquileresMensualAsync(
                criteria.FechaDesde, criteria.FechaHasta, sucursalId);

            var sucursales = (await _sucursalRepository.GetAllAsync())
                .Where(s => !sucursalId.HasValue || s.Id == sucursalId.Value)
                .ToList();

            var primerMes = new DateTime(criteria.FechaDesde.Year, criteria.FechaDesde.Month, 1);
            var ultimoMes = new DateTime(criteria.FechaHasta.Year, criteria.FechaHasta.Month, 1);

            var resultado = new List<ReporteAlquileresDTO>();

            for (var mes = primerMes; mes <= ultimoMes; mes = mes.AddMonths(1))
            {
                foreach (var sucursal in sucursales)
                {
                    var fila = alquileres.FirstOrDefault(a =>
                        a.Anio == mes.Year &&
                        a.Mes == mes.Month &&
                        a.SucursalId == sucursal.Id);

                    resultado.Add(new ReporteAlquileresDTO
                    {
                        Anio = mes.Year,
                        Mes = mes.Month,
                        SucursalId = sucursal.Id,
                        Sucursal = sucursal.Nombre,
                        CantidadAlquileres = fila?.CantidadAlquileres ?? 0
                    });
                }
            }

            return resultado;
        }
    }
}