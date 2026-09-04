using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class CategoriaApiClient : BaseApiClient
    {
        public static async Task<CategoriaDTO?> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"categorias/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<CategoriaDTO>();
                }
                else
                {
                    throw new Exception($"Error al obtener categoría con Id {id}. Status: {response.StatusCode}");
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

        public static async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("categorias");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<CategoriaDTO>>() ?? new List<CategoriaDTO>();
                }
                else
                {
                    throw new Exception("Error al obtener categorías. Status: " + response.StatusCode);
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

        public static async Task AddAsync(CategoriaDTO categoria)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("categorias", categoria);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al crear categoría. Status: " + response.StatusCode);
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

        public static async Task UpdateAsync(CategoriaDTO categoria)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PutAsJsonAsync("categorias", categoria);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al actualizar categoría. Status: " + response.StatusCode);
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
                HttpResponseMessage response = await client.DeleteAsync($"categorias/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al eliminar categoría con Id {id}. Status: {response.StatusCode}");
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