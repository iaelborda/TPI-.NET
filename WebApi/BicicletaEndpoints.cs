using Application.Services;
using DTOs;

namespace WebApi
{
    public static class BicicletaEndpoints
    {
        public static void MapBicicletaEndpoints(this WebApplication app)
        {
            app.MapGet("/bicicletas/{id}", async (int id, IBicicletaService bicicletaService) =>
            {
                BicicletaDTO? dto = await bicicletaService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetBicicleta")
            .Produces<BicicletaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/bicicletas", async (IBicicletaService bicicletaService) =>
            {
                var dtos = await bicicletaService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllBicicletas")
            .Produces<List<BicicletaDTO>>(StatusCodes.Status200OK);

            app.MapPost("/bicicletas", async (BicicletaDTO dto, IBicicletaService bicicletaService) =>
            {
                try
                {
                    BicicletaDTO bicicletaDTO = await bicicletaService.AddAsync(dto);

                    return Results.Created($"/bicicletas/{bicicletaDTO.Id}", bicicletaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddBicicleta")
            .Produces<BicicletaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/bicicletas", async (BicicletaDTO dto, IBicicletaService bicicletaService) =>
            {
                try
                {
                    var found = await bicicletaService.UpdateAsync(dto);

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
            .WithName("UpdateBicicleta")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/bicicletas/{id}", async (int id, IBicicletaService bicicletaService) =>
            {
                var deleted = await bicicletaService.DeleteAsync(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteBicicleta")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
