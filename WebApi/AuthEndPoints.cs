using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/login", async (LoginRequestDTO request) =>
            {
                AuthService authService = new AuthService(
                    app.Services.GetRequiredService<IConfiguration>());

                var response = await authService.LoginAsync(request);

                if (response == null)
                    return Results.Unauthorized();

                return Results.Ok(response);
            })
            .WithName("Login")
            .Produces<LoginResponseDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithOpenApi();
        }
    }
}