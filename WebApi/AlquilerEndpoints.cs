using Application.Services;
using DTOs;

namespace WebApi
{
    public static class AlquilerEndpoints
    {
        public static void MapAlquilerEndpoints(this WebApplication app)
        {
            app.MapGet("/alquileres/{id}", async (int id) =>
            {
                AlquilerService alquilerService = new AlquilerService();
                AlquilerDTO? dto = await alquilerService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetAlquiler")
            .Produces<AlquilerDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("AlquileresLeer");

            app.MapGet("/alquileres", async () =>
            {
                AlquilerService alquilerService = new AlquilerService();
                var dtos = await alquilerService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllAquileres")
            .Produces<AlquilerDTO>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("AlquileresLeer");

            app.MapPost("/alquileres", async (AlquilerDTO dto) =>
            {
                try
                {
                    AlquilerService alquilerService = new AlquilerService();
                    AlquilerDTO alquilerDTO = await alquilerService.AddAsync(dto);
                    return Results.Created($"/alquileres/{alquilerDTO.Id}", alquilerDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAquiler")
            .Produces<AlquilerDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("AlquileresAgregar");

            app.MapPut("/alquileres", async (AlquilerDTO dto) =>
            {
                try
                {
                    AlquilerService alquilerService = new AlquilerService();
                    var found = await alquilerService.UpdateAsync(dto);

                    if (!found)
                    {
                        return Results.NotFound();
                    }
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateAquiler")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("AlquileresActualizar");

            app.MapDelete("/alquileres/{id}", async (int id) =>
            {
                AlquilerService alquilerService = new AlquilerService();
                var deleted = await alquilerService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteAquiler")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("AlquileresEliminar");
        }
    }
}
