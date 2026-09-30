using Application.Services;
using DTOs;

namespace WebApi
{
    public static class TarifaEndpoints
    {
        public static void MapTarifaEndpoints(this WebApplication app)
        {
            app.MapGet("/tarifas/{id}", async (int id, ITarifaService tarifaService) =>
            {
                TarifaDTO? dto = await tarifaService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetTarifa")
            .Produces<TarifaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("TarifasLeer");

            app.MapGet("/tarifas", async (ITarifaService tarifaService) =>
            {
                var dtos = await tarifaService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllTarifas")
            .Produces<List<TarifaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("TarifasLeer");

            app.MapGet("/tarifas/categoria/{categoriaId}", async (int categoriaId, ITarifaService tarifaService) =>
            {
                var dtos = await tarifaService.GetByCategoriaIdAsync(categoriaId);
                return Results.Ok(dtos);
            })
            .WithName("GetTarifasByCategoria")
            .Produces<List<TarifaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("TarifasLeer");

            app.MapPost("/tarifas", async (TarifaDTO dto, ITarifaService tarifaService) =>
            {
                try
                {
                    TarifaDTO tarifaDTO = await tarifaService.AddAsync(dto);
                    return Results.Created($"/tarifas/{tarifaDTO.Id}", tarifaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddTarifa")
            .Produces<TarifaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("TarifasAgregar");

            app.MapPut("/tarifas", async (TarifaDTO dto, ITarifaService tarifaService) =>
            {
                try
                {
                    var found = await tarifaService.UpdateAsync(dto);
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
            .WithName("UpdateTarifa")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("TarifasActualizar");

            app.MapDelete("/tarifas/{id}", async (int id, ITarifaService tarifaService) =>
            {
                var deleted = await tarifaService.DeleteAsync(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteTarifa")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("TarifasEliminar");
        }
    }
}
