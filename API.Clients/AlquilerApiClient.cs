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

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se encontró el alquiler. Verifique si el Id existe.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<AlquilerDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener el alquiler: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener el alquiler: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<AlquilerDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("alquileres");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron obtener los alquileres.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<IEnumerable<AlquilerDTO>>() ?? new List<AlquilerDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener los alquileres: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener los alquileres: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(AlquilerDTO alquiler)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("alquileres", alquiler);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo registrar el alquiler. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear el alquiler: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear el alquiler: {ex.Message}", ex);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo eliminar el alquiler. Verifique si tiene operaciones asociadas.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar el alquiler: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar el alquiler: {ex.Message}", ex);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo actualizar el alquiler. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar el alquiler: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar el alquiler: {ex.Message}", ex);
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

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron filtrar los alquileres. Revise los filtros e intente nuevamente.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<IEnumerable<AlquilerDTO>>() ?? new List<AlquilerDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al filtrar los alquileres: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al filtrar los alquileres: {ex.Message}", ex);
            }
        }
    }
}