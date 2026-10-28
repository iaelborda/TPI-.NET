using System.Net.Http.Headers;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        protected static async Task<HttpClient> CreateHttpClientAsync()
        {
            var client = new HttpClient();
            await ConfigureHttpClientAsync(client);
            return client;
        }

        protected static async Task ConfigureHttpClientAsync(HttpClient client)
        {
            string baseUrl = GetBaseUrlFromConfig();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            await AddAuthorizationHeaderAsync(client);
        }

        private static string GetBaseUrlFromConfig()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Intentando leer configuración...");

                string? envUrl = Environment.GetEnvironmentVariable("TPI_API_BASE_URL");
                if (!string.IsNullOrEmpty(envUrl))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] URL desde variable de entorno: {envUrl}");
                    return envUrl;
                }

                string runtimeInfo = System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier;
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Runtime: {runtimeInfo}");

                if (runtimeInfo.StartsWith("android"))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Detectado Android");
                    return "http://10.0.2.2:5183/";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Error: {ex.Message}");
            }

            string defaultUrl = "https://localhost:7261/";
            System.Diagnostics.Debug.WriteLine($"[DEBUG] Usando URL: {defaultUrl}");
            return defaultUrl;
        }

        protected static async Task AddAuthorizationHeaderAsync(HttpClient client)
        {
            var authService = AuthServiceProvider.Instance;

            await authService.CheckTokenExpirationAsync();

            var token = await authService.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
        protected static async Task<string> ObtenerMensajeErrorAsync(HttpResponseMessage response, string mensajePredeterminado)
        {
            string contenido = await response.Content.ReadAsStringAsync();

            try
            {
                using var documento = System.Text.Json.JsonDocument.Parse(contenido);
                var datos = documento.RootElement;

                if (datos.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    if (datos.TryGetProperty("message", out var mensaje) &&
                        mensaje.ValueKind == System.Text.Json.JsonValueKind.String)
                    {
                        return mensaje.GetString() ?? mensajePredeterminado;
                    }

                    if (datos.TryGetProperty("detail", out var detalle) &&
                        detalle.ValueKind == System.Text.Json.JsonValueKind.String)
                    {
                        return detalle.GetString() ?? mensajePredeterminado;
                    }

                    if (datos.TryGetProperty("errors", out var errores))
                    {
                        var mensajes = new List<string>();

                        if (errores.ValueKind == System.Text.Json.JsonValueKind.String)
                        {
                            string? texto = errores.GetString();

                            if (!string.IsNullOrWhiteSpace(texto))
                            {
                                mensajes.Add(texto);
                            }
                        }
                        else if (errores.ValueKind == System.Text.Json.JsonValueKind.Object)
                        {
                            foreach (var error in errores.EnumerateObject())
                            {
                                if (error.Value.ValueKind == System.Text.Json.JsonValueKind.Array)
                                {
                                    foreach (var item in error.Value.EnumerateArray())
                                    {
                                        if (item.ValueKind == System.Text.Json.JsonValueKind.String)
                                        {
                                            string? texto = item.GetString();

                                            if (!string.IsNullOrWhiteSpace(texto))
                                            {
                                                mensajes.Add(texto);
                                            }
                                        }
                                    }
                                }
                                else if (error.Value.ValueKind == System.Text.Json.JsonValueKind.String)
                                {
                                    string? texto = error.Value.GetString();

                                    if (!string.IsNullOrWhiteSpace(texto))
                                    {
                                        mensajes.Add(texto);
                                    }
                                }
                            }
                        }

                        if (mensajes.Count > 0)
                        {
                            return string.Join(" ", mensajes);
                        }
                    }

                    if (datos.ValueKind == System.Text.Json.JsonValueKind.Object &&
                        datos.TryGetProperty("title", out var titulo) &&
                        titulo.ValueKind == System.Text.Json.JsonValueKind.String)
                    {
                        return titulo.GetString() ?? mensajePredeterminado;
                    }
                }
                else if (datos.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    return datos.GetString() ?? mensajePredeterminado;
                }
            }
            catch (System.Text.Json.JsonException)
            {
            }

            return response.StatusCode switch
            {
                System.Net.HttpStatusCode.NotFound => "No se encontró el registro solicitado.",
                System.Net.HttpStatusCode.Unauthorized => "La sesión no es válida. Iniciá sesión nuevamente.",
                System.Net.HttpStatusCode.Forbidden => "No tenés permisos para realizar esta operación.",
                System.Net.HttpStatusCode.Conflict => "No se puede realizar la operación porque existe un conflicto con los datos.",
                _ => mensajePredeterminado
            };
        }
    }
}