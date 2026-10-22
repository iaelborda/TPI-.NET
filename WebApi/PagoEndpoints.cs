using Application.Services;
using DTOs;

namespace WebApi
{
    public static class PagoEndpoints
    {
        public static void MapPagoEndpoints(this WebApplication app)
        {
            app.MapGet("/pagos/{id}", async (int id, IPagoService pagoService) =>
            {
                PagoDTO? dto = await pagoService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPago")
            .Produces<PagoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("PagosLeer");

            app.MapGet("/pagos/alquiler/{alquilerId}", async (int alquilerId, IPagoService pagoService) =>
            {
                PagoDTO? dto = await pagoService.GetByAlquilerIdAsync(alquilerId);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetPagoByAlquilerId")
            .Produces<PagoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("PagosLeer");

            app.MapGet("/pagos", async (IPagoService pagoService) =>
            {
                var dtos = await pagoService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllPagos")
            .Produces<IEnumerable<PagoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("PagosLeer");

            app.MapPost("/pagos", async (PagoDTO dto, IPagoService pagoService) =>
            {
                try
                {
                    PagoDTO pagoDTO = await pagoService.AddAsync(dto);

                    return Results.Created($"/pagos/{pagoDTO.IdPago}", pagoDTO);
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
            .WithName("AddPago")
            .Produces<PagoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("PagosAgregar");

            app.MapPut("/pagos", async (PagoDTO dto, IPagoService pagoService) =>
            {
                try
                {
                    var found = await pagoService.UpdateAsync(dto);

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
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePago")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("PagosActualizar");

            app.MapDelete("/pagos/{id}", async (int id, IPagoService pagoService) =>
            {
                var deleted = await pagoService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeletePago")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("PagosEliminar");
        }
    }
}
