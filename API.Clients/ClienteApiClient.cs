using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class ClienteApiClient : BaseApiClient
    {
        public static async Task<ClienteDTO?> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync($"clientes/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se encontró el cliente. Verifique si el Id existe.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<ClienteDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener el cliente: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener el cliente: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.GetAsync("clientes");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudieron obtener los clientes.");
                    throw new Exception(mensaje);
                }

                return await response.Content.ReadAsAsync<IEnumerable<ClienteDTO>>() ?? new List<ClienteDTO>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener los clientes: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener los clientes: {ex.Message}", ex);
            }
        }

        public static async Task AddAsync(ClienteDTO cliente)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PostAsJsonAsync("clientes", cliente);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo crear el cliente. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear el cliente: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear el cliente: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(ClienteDTO cliente)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.PutAsJsonAsync("clientes", cliente);

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo actualizar el cliente. Verifique los datos ingresados.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar el cliente: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar el cliente: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response = await client.DeleteAsync($"clientes/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string mensaje = await ObtenerMensajeErrorAsync(response, "No se pudo eliminar el cliente. Verifique si tiene operaciones asociadas.");
                    throw new Exception(mensaje);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar el cliente: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar el cliente: {ex.Message}", ex);
            }
        }
    }
}