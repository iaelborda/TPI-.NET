using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class SucursalApiClient : BaseApiClient
    {
        public static async Task<SucursalDTO?> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"sucursales/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<SucursalDTO>();
                }
                else
                {
                    throw new Exception($"Error al obtener sucursal con Id {id}. Status: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<SucursalDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("sucursales");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<SucursalDTO>>() ?? new List<SucursalDTO>();
                }
                else
                {
                    throw new Exception("Error al obtener sucursales. Status: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(SucursalDTO sucursal)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("sucursales", sucursal);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al crear sucursal. Status: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(SucursalDTO sucursal)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PutAsJsonAsync("sucursales", sucursal);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al actualizar sucursal. Status: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.DeleteAsync($"sucursales/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"La sucursal {id} tiene bicicletas asociadas. Status: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout: {ex.Message}", ex);
            }
        }
    }
}