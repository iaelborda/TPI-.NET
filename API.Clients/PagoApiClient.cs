using DTOs;
using System.Net;
using System.Net.Http.Json;

namespace API.Clients
{
    public class PagoApiClient : BaseApiClient
    {
        public static async Task<PagoDTO?> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"pagos/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se encontró el pago. Verifique si el Id existe.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<PagoDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener el pago: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener el pago: {ex.Message}", ex);
            }
        }

        public static async Task<PagoDTO?> GetByAlquilerIdAsync(int alquilerId)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"pagos/alquiler/{alquilerId}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo obtener el pago del alquiler.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<PagoDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener el pago del alquiler: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener el pago del alquiler: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<PagoDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("pagos");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron obtener los pagos.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<IEnumerable<PagoDTO>>() ?? new List<PagoDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener los pagos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener los pagos: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(PagoDTO pago)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("pagos", pago);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo registrar el pago. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear el pago: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear el pago: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(PagoDTO pago)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PutAsJsonAsync("pagos", pago);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo actualizar el pago. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar el pago: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar el pago: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.DeleteAsync($"pagos/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo eliminar el pago. Verifique si el Id existe.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar el pago con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar el pago con Id {id}: {ex.Message}", ex);
            }
        }
    }
}