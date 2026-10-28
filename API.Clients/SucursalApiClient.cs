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

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se encontró la sucursal. Verifique si el Id existe.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<SucursalDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener la sucursal: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener la sucursal: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<SucursalDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("sucursales");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron obtener las sucursales.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<IEnumerable<SucursalDTO>>() ?? new List<SucursalDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener las sucursales: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener las sucursales: {ex.Message}", ex);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo crear la sucursal. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear la sucursal: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear la sucursal: {ex.Message}", ex);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo actualizar la sucursal. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar la sucursal: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar la sucursal: {ex.Message}", ex);
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
                    string mensaje = await ObtenerMensajeErrorAsync(response, $"No se pudo eliminar la sucursal con Id {id}. Verifique si tiene bicicletas asociadas.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar la sucursal con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar la sucursal con Id {id}: {ex.Message}", ex);
            }
        }
    }
}