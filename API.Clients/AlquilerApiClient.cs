using DTOs;
using System.Globalization;
using System.Net.Http.Json;

namespace API.Clients
{
    public class AlquilerApiClient : BaseApiClient
    {
        public static async Task<AlquilerDTO> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("alquileres/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AlquilerDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al obtener alquiler con Id {id}. " + $"Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener alquiler con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener alquiler con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<AlquilerDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("alquileres");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AlquilerDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al obtener lista de alquileres. " + $"Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de alquileres: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de alquileres: {ex.Message}", ex);
            }
        }
        private static async Task<string> ObtenerMensajeErrorAsync(HttpResponseMessage response)
        {
            string contenido = await response.Content.ReadAsStringAsync();

            try
            {
                var error = System.Text.Json.JsonDocument.Parse(contenido);

                if (error.RootElement.TryGetProperty("error", out var mensaje))
                    return mensaje.GetString() ?? contenido;
            }
            catch
            {
            }

            return contenido;
        }
        public static async Task AddAsync(AlquilerDTO alquiler)
        {
            try
            {
                using var client = await CreateHttpClientAsync();

                HttpResponseMessage response = await client.PostAsJsonAsync("alquileres", alquiler);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response);
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear alquiler: {ex.Message}", ex
                );
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear alquiler: {ex.Message}", ex
                );
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();

                HttpResponseMessage response = await client.DeleteAsync("alquileres/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al eliminar alquiler con Id {id}. " + $"Status: {response.StatusCode}, Detalle: {errorContent}"
                    );
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar alquiler con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar alquiler con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(AlquilerDTO alquiler)
        {
            try
            {
                using var client = await CreateHttpClientAsync();

                HttpResponseMessage response = await client.PutAsJsonAsync("alquileres", alquiler);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response);
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar alquiler con Id {alquiler.Id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar alquiler con Id {alquiler.Id}: {ex.Message}", ex);
            }
        }
        public static async Task<IEnumerable<AlquilerDTO>> GetByCriteriaAsync(DateTime desde, DateTime hasta, int? sucursalId)
        {
            try
            {
                using var client = await CreateHttpClientAsync();

                string url = $"alquileres/criteria?fechaDesde={desde.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}" +
                             $"&fechaHasta={hasta.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}";

                if (sucursalId.HasValue)
                    url += $"&sucursalId={sucursalId.Value}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AlquilerDTO>>();
                }
                else
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response);

                    throw new Exception($"Error al filtrar alquileres. Status: {response.StatusCode}, Detalle: {mensaje}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al filtrar alquileres: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al filtrar alquileres: {ex.Message}", ex);
            }
        }
    }
}