using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class ReporteApiClient : BaseApiClient
    {
        public static async Task<byte[]> GetReporteAlquileresAsync(ReporteAlquileresCriteriaDTO criteria)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("reportes/alquileres", criteria);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo generar el reporte de alquileres. Verifique los filtros ingresados.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar el reporte de alquileres: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar el reporte de alquileres: {ex.Message}", ex);
            }
        }

        public static async Task<byte[]> GetTop10BicicletasAnioAsync(ReporteRankingBicicletaCriteriaDTO criteria)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("reportes/top10-bicicletas", criteria);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo generar el ranking de las 10 bicicletas. Verifique los filtros ingresados.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar el ranking de bicicletas: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar el ranking de bicicletas: {ex.Message}", ex);
            }
        }
    }
}