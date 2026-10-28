using DTOs;
using System.Net;
using System.Net.Http.Json;

namespace API.Clients
{
    public class TarifaApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<TarifaDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync("tarifas");

            if (!response.IsSuccessStatusCode)
            {
                string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron obtener las tarifas.");
                throw new Exception(mensaje);
            }

            return await response.Content.ReadAsAsync<IEnumerable<TarifaDTO>>() ?? new List<TarifaDTO>();
        }

        public static async Task<TarifaDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"tarifas/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
            {
                string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo obtener la tarifa. Verifique si el Id existe.");
                throw new Exception(mensaje);
            }

            return await response.Content.ReadAsAsync<TarifaDTO>();
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.DeleteAsync($"tarifas/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            if (!response.IsSuccessStatusCode)
            {
                string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo eliminar la tarifa. Verifique si tiene operaciones asociadas.");
                throw new Exception(mensaje);
            }

            return true;
        }

        public static async Task<TarifaDTO?> GetTarifaVigenteAsync(int categoriaId)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.GetAsync($"tarifas/categoria/{categoriaId}/vigente");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
            {
                string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo obtener la tarifa vigente de la categoría.");
                throw new Exception(mensaje);
            }

            return await response.Content.ReadAsAsync<TarifaDTO>();
        }

        public static async Task AddAsync(TarifaDTO tarifa)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.PostAsJsonAsync("tarifas", tarifa);

            if (!response.IsSuccessStatusCode)
            {
                string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo crear la tarifa. Verifique los datos ingresados.");
                throw new Exception(mensaje);
            }
        }

        public static async Task UpdateAsync(TarifaDTO tarifa)
        {
            using var client = await CreateHttpClientAsync();
            HttpResponseMessage response = await client.PutAsJsonAsync("tarifas", tarifa);

            if (!response.IsSuccessStatusCode)
            {
                string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo actualizar la tarifa. Verifique los datos ingresados.");
                throw new Exception(mensaje);
            }
        }
    }
}