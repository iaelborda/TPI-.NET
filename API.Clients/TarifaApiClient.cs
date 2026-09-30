using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class TarifaApiClient : BaseApiClient
    {
        public static async Task<TarifaDTO?> GetTarifaVigenteAsync(int categoriaId)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"tarifas/categoria/{categoriaId}/vigente");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<TarifaDTO>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener tarifa vigente de la categoría {categoriaId}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener tarifa vigente: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener tarifa vigente: {ex.Message}", ex);
            }
        }
    }
}
