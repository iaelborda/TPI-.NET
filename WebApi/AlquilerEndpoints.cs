using Application.Services;
using DTOs;

namespace WebApi
{
    public static class AlquilerEndpoints
    {
        public static void MapAlquilerEndpoints(this WebApplication app)
        {
            app.MapGet("/alquileres/{id}", async (int id, AlquilerService alquilerService) =>
            {
                var dto = await alquilerService.GetAsync(id);

                if (dto == null)
                    return Results.NotFound();

                return Results.Ok(dto);
            })
            .WithName("GetAlquiler")
            .Produces<AlquilerDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("AlquileresLeer");

            app.MapGet("/alquileres", async (AlquilerService alquilerService) =>
            {
                var dtos = await alquilerService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllAquileres")
            .Produces<IEnumerable<AlquilerDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("AlquileresLeer");

            app.MapPost("/alquileres", async (AlquilerDTO dto, AlquilerService alquilerService) =>
            {
                try
                {
                    var alquilerDTO = await alquilerService.AddAsync(dto);
                    return Results.Created($"/alquileres/{alquilerDTO.Id}", alquilerDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAquiler")
            .Produces<AlquilerDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("AlquileresAgregar");

            app.MapPut("/alquileres", async (AlquilerDTO dto, AlquilerService alquilerService) =>
            {
                try
                {
                    var found = await alquilerService.UpdateAsync(dto);

                    if (!found)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateAquiler")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("AlquileresActualizar");

            app.MapDelete("/alquileres/{id}", async (int id, AlquilerService alquilerService) =>
            {
                try
                {
                    var deleted = await alquilerService.DeleteAsync(id);

                    if (!deleted)
                        return Results.NotFound();

                    return Results.NoContent();
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("DeleteAquiler")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("AlquileresEliminar");

            app.MapGet("/alquileres/criteria", async ([AsParameters] ReporteAlquileresCriteriaDTO criteria, AlquilerService alquilerService) =>
            {
                try
                {
                    var alquileres = await alquilerService.GetByCriteriaAsync(criteria);
                    return Results.Ok(alquileres);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("GetAlquileresByCriteria")
            .Produces<IEnumerable<AlquilerDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("AlquileresLeer");
        }
    }
}
