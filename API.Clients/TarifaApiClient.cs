using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class TarifaApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<TarifaDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync("tarifas");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<TarifaDTO>>();
            }

            string errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al obtener tarifas. Status: {response.StatusCode}, Detalle: {errorContent}");
        }

        public static async Task<TarifaDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"tarifas/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TarifaDTO>();
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            string errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al obtener tarifa {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.DeleteAsync($"tarifas/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            string errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al eliminar tarifa {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
        }

        public static async Task<TarifaDTO?> GetTarifaVigenteAsync(int categoriaId)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"tarifas/categoria/{categoriaId}/vigente");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TarifaDTO>();
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            string errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al obtener tarifa vigente de la categoría {categoriaId}. Status: {response.StatusCode}, Detalle: {errorContent}");
        }
        public static async Task AddAsync(TarifaDTO tarifa)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.PostAsJsonAsync("tarifas", tarifa);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear tarifa. Status: {response.StatusCode}, Detalle: {errorContent}");
            }
        }

        public static async Task UpdateAsync(TarifaDTO tarifa)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.PutAsJsonAsync("tarifas", tarifa);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar tarifa. Status: {response.StatusCode}, Detalle: {errorContent}");
            }
        }
    }
}