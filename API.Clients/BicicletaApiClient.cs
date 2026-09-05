using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class BicicletaApiClient : BaseApiClient
    {
        public static async Task<BicicletaDTO?> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"bicicletas/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<BicicletaDTO>();
                }
                else
                {
                    throw new Exception($"Error al obtener bicicleta con Id {id}. Status: {response.StatusCode}");
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

        public static async Task<IEnumerable<BicicletaDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("bicicletas");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<BicicletaDTO>>() ?? new List<BicicletaDTO>();
                }
                else
                {
                    throw new Exception("Error al obtener bicicletas. Status: " + response.StatusCode);
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

        public static async Task AddAsync(BicicletaDTO bicicleta)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("bicicletas", bicicleta);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No se puede asignar la bicicleta porque la sucursal alcanzó su capacidad máxima. Status: " + response.StatusCode);
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

        public static async Task UpdateAsync(BicicletaDTO bicicleta)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PutAsJsonAsync("bicicletas", bicicleta);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No se puede asignar la bicicleta porque la sucursal alcanzó su capacidad máxima. Status: " + response.StatusCode);
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
                HttpResponseMessage response = await client.DeleteAsync($"bicicletas/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al eliminar bicicleta con Id {id}. Status: {response.StatusCode}");
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