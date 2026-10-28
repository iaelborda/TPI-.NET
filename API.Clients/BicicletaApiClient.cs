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

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se encontró la bicicleta. Verifique si el Id existe.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<BicicletaDTO>();
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

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron obtener las bicicletas.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<IEnumerable<BicicletaDTO>>() ?? new List<BicicletaDTO>();
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

        public static async Task<IEnumerable<BicicletaDTO>> GetByCriteriaAsync(BicicletaCriteriaDTO dto)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("bicicletas/buscar", dto);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron buscar las bicicletas. Revise los filtros e intente nuevamente.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<IEnumerable<BicicletaDTO>>() ?? new List<BicicletaDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar bicicletas: {ex.Message}", ex);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo crear la bicicleta. Verifique los datos ingresados.");

                    throw new Exception(mensaje);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo actualizar la bicicleta. Verifique los datos ingresados.");

                    throw new Exception(mensaje);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo eliminar la bicicleta. Verifique que no tenga operaciones asociadas.");

                    throw new Exception(mensaje);
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