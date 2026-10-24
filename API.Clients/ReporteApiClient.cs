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
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al generar el reporte. Status: {response.StatusCode}, Detalle: {errorContent}");
                }

                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al generar el reporte: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al generar el reporte: {ex.Message}", ex);
            }
        }
    }
}