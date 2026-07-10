using Application.Services;
using DTOs;


namespace WebApi
{
    public static class SucursalEndpoints
    {
        public static void MapSucursalEndpoints(this WebApplication app)
        {
            app.MapGet("/sucursales/{id}", async (int id, ISucursalService sucursalService) =>
            {
                SucursalDTO? dto = await sucursalService.GetAsync(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetSucursal")
            .Produces<SucursalDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/sucursales", async (ISucursalService sucursalService) =>
            {
                var dtos = await sucursalService.GetAllAsync();
                return Results.Ok(dtos);
            }).WithName("GetAllSucursales")
              .Produces<List<SucursalDTO>>(StatusCodes.Status200OK);

            app.MapPost("/sucursales", async (SucursalDTO dto, ISucursalService sucursalService) =>
            {
                try
                {
                    SucursalDTO sucursalDTO = await sucursalService.AddAsync(dto);
                    return Results.Created($"/sucursales/{sucursalDTO.Id}", sucursalDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddSucursal")
            .Produces<SucursalDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/sucursales/{id}", async (int id, ISucursalService sucursalService) =>
            {
                var deleted = await sucursalService.DeleteAsync(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteSucursales")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

            app.MapPut("/sucursales/{id}", async (SucursalDTO dto, ISucursalService sucursalService) =>
            {
                try
                {
                    var found = await sucursalService.UpdateAsync(dto);
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
            .WithName("UpdateSucursal")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
