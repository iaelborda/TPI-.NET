using Application.Services;
using DTOs;


namespace WebApi
{
    public static class CategoriaEndpoints
    {
        public static void MapCategoriaEndpoints(this WebApplication app)
        {
            app.MapGet("/categorias", async (ICategoriaService categoriaService) =>
            {
                var dtos = await categoriaService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllCategorias")
            .Produces<IEnumerable<CategoriaDTO>>(StatusCodes.Status200OK);

            app.MapGet("/categorias/{id}", async (int id, ICategoriaService categoriaService) =>
            {
                CategoriaDTO? dto = await categoriaService.GetAsync(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetCategoriaById")
            .Produces<CategoriaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapPost("/categorias", async (CategoriaDTO dto, ICategoriaService categoriaService) =>
            {
                try
                {
                    CategoriaDTO categoriaDTO = await categoriaService.AddAsync(dto);
                    return Results.Created($"/categorias/{categoriaDTO.Id}", categoriaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCategoria")
            .Produces<CategoriaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/categorias/{id}", async (CategoriaDTO dto, ICategoriaService categoriaService) =>
            {
                try
                {
                    var found = await categoriaService.UpdateAsync(dto);
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
            .WithName("UpdateCategoria")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/categorias/{id}", async (int id, ICategoriaService categoriaService) =>
            {
                var deleted = await categoriaService.DeleteAsync(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteCategoria")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}


