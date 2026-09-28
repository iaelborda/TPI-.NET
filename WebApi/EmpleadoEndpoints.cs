using Application.Services;
using DTOs;

namespace WebApi
{
    public static class EmpleadoEndpoints
    {
        public static void MapEmpleadoEndpoints(this WebApplication app)
        {
            app.MapGet("/empleados/{id}", async (int id, IEmpleadoService empleadoService) =>
            {
                EmpleadoDTO? dto = await empleadoService.GetAsync(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetEmpleado")
            .Produces<EmpleadoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("EmpleadosLeer"); 

            app.MapGet("/empleados", async (IEmpleadoService empleadoService) =>
            {
                var dtos = await empleadoService.GetAllAsync();
                return Results.Ok(dtos);
            })
            .WithName("GetAllEmpleados")
            .Produces<List<EmpleadoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi()
            .RequireAuthorization("EmpleadosLeer");

            app.MapPost("/empleados", async (EmpleadoDTO dto, IEmpleadoService empleadoService) =>
            {
                try
                {
                    EmpleadoDTO empleadoDTO = await empleadoService.AddAsync(dto);
                    return Results.Created($"/empleados/{empleadoDTO.Id}", empleadoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddEmpleado")
            .Produces<EmpleadoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("EmpleadosAgregar"); 

            app.MapPut("/empleados", async (EmpleadoDTO dto, IEmpleadoService empleadoService) =>
            {
                try
                {
                    var found = await empleadoService.UpdateAsync(dto);
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
            .WithName("UpdateEmpleado")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi()
            .RequireAuthorization("EmpleadosModificar"); 

            app.MapDelete("/empleados/{id}", async (int id, IEmpleadoService empleadoService) =>
            {
                var deleted = await empleadoService.DeleteAsync(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteEmpleado")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi()
            .RequireAuthorization("EmpleadosEliminar"); 
        }
    }
}
