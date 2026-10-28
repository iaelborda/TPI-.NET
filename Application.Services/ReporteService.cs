using Data;
using DTOs;
using System.Data;

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
            if (criteria.FechaDesde < new DateTime(2000, 1, 1) ||
                criteria.FechaHasta < new DateTime(2000, 1, 1))
                throw new ArgumentException("Las fechas no pueden ser anteriores al 01/01/2000.");

            if (criteria.FechaDesde.Date > DateTime.Today ||
                criteria.FechaHasta.Date > DateTime.Today)
                throw new ArgumentException("Las fechas no pueden ser futuras.");

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
        public async Task<List<ReporteRankingBicicletaDTO>> ObtenerTop10BicicletasAnioAsync(int anio)
        {
            if (anio < 2000 || anio > DateTime.Today.Year)
                throw new ArgumentException("El año debe estar entre 2000 y el año actual.");

            var datos = await _alquilerRepository.GetTop10BicicletasAnioAsync(anio);

            return datos.Select((item, indice) => new ReporteRankingBicicletaDTO
            {
                Puesto = indice + 1,
                IdBicicleta = item.IdBicicleta,
                Marca = item.Marca,
                Modelo = item.Modelo,
                CantAlquileres = item.CantAlquileres
            }).ToList();
        }
    }
}