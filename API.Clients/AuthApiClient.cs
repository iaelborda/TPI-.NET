using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            using var client = await CreateHttpClientAsync();

            HttpResponseMessage response =
                await client.PostAsJsonAsync("login", request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
            }

            return null;
        }
    }
}