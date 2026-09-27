using DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class AlquilerApiClient : BaseApiClient
    {
        public static async Task<AlquilerDTO> GetAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response =await client.GetAsync("alquileres/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AlquilerDTO>();
                }
                else
                {
                    string errorContent =await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al obtener alquiler con Id {id}. " +$"Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener alquiler con Id {id}: {ex.Message}",ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener alquiler con Id {id}: {ex.Message}",ex);
            }
        }

        public static async Task<IEnumerable<AlquilerDTO>> GetAllAsync()
        {
            try
            {
                using var client = await CreateHttpClientAsync();
                HttpResponseMessage response =await client.GetAsync("alquileres");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<AlquilerDTO>>();
                }
                else
                {
                    //await HandleUnauthorizedResponseAsync(response);

                    string errorContent =await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al obtener lista de alquileres. " +$"Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de alquileres: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de alquileres: {ex.Message}",ex);
            }
        }

        public static async Task AddAsync(AlquilerDTO alquiler)
        {
            try
            {
                using var client = await CreateHttpClientAsync();

                HttpResponseMessage response =await client.PostAsJsonAsync("alquileres", alquiler);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent =await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al crear alquiler. " + $"Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear alquiler: {ex.Message}",ex
                );
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear alquiler: {ex.Message}",ex
                );
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                using var client = await CreateHttpClientAsync();

                HttpResponseMessage response =await client.DeleteAsync("alquileres/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent =await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al eliminar alquiler con Id {id}. " +$"Status: {response.StatusCode}, Detalle: {errorContent}"
                    );
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar alquiler con Id {id}: {ex.Message}",ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar alquiler con Id {id}: {ex.Message}",ex);
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
                    string errorContent =await response.Content.ReadAsStringAsync();

                    throw new Exception($"Error al actualizar alquiler con Id {alquiler.Id}. " + $"Status: {response.StatusCode}, Detalle: {errorContent}"
                    );
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar alquiler con Id {alquiler.Id}: {ex.Message}",ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar alquiler con Id {alquiler.Id}: {ex.Message}", ex);
            }
        }
    }
}