using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ClienteEndpoints
    {
        public static void MapClienteEndpoints(this WebApplication app)
        {
            app.MapGet("/clientes/{documento}", async (string documento, IClienteService clienteService) =>
            {
                ClienteDTO? dto = await clienteService.GetAsync(documento);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetCliente")
            .Produces<ClienteDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            app.MapGet("/clientes", async (IClienteService clienteService) =>
            {
                var dtos = await clienteService.GetAllAsync();

                return Results.Ok(dtos);
            })
            .WithName("GetAllClientes")
            .Produces<List<ClienteDTO>>(StatusCodes.Status200OK);

            app.MapPost("/clientes", async (ClienteDTO dto, IClienteService clienteService) =>
            {
                try
                {
                    ClienteDTO clienteDTO = await clienteService.AddAsync(dto);

                    return Results.Created($"/clientes/{clienteDTO.Documento}", clienteDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCliente")
            .Produces<ClienteDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapPut("/clientes", async (ClienteDTO dto, IClienteService clienteService) =>
            {
                try
                {
                    var found = await clienteService.UpdateAsync(dto);

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
            .WithName("UpdateCliente")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

            app.MapDelete("/clientes/{documento}", async (string documento, IClienteService clienteService) =>
            {
                var deleted = await clienteService.DeleteAsync(documento);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteCliente")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}