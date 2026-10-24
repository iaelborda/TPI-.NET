using Application.Services;
using DTOs;

namespace WebApi
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this WebApplication app)
        {
            app.MapPost("/reportes/alquileres", async (ReporteAlquileresCriteriaDTO criteria, IReporteService reporteService, ReportePdfService reportePdfService) =>
            {
                try
                {
                    var datos = await reporteService.ObtenerReporteAlquileresAsync(criteria);

                    var pdf = reportePdfService.GenerarReporteAlquileres(datos, criteria.FechaDesde, criteria.FechaHasta);

                    return Results.File(pdf, "application/pdf", "ReporteAlquileres.pdf");
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
            .WithName("GetReporteAlquileres")
            .Produces(StatusCodes.Status200OK, contentType: "application/pdf")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status403Forbidden)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");

            app.MapPost("/reportes/ranking-bicicletas", async (ReporteRankingBicicletaCriteriaDTO criteria, IReporteService reporteService, ReportePdfService reportePdfService) =>
            {
                try
                {
                    var datos = await reporteService.ObtenerRankingBicicletasAsync(criteria);

                    var pdf = reportePdfService.GenerarReporteRankingBicicletas(datos, criteria.FechaDesde!.Value, criteria.FechaHasta!.Value, criteria.Top);
                    return Results.File(pdf, "application/pdf", "RankingBicicletas.pdf");
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            }).WithName("GetRankingBicicletas")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status403Forbidden)
            .WithOpenApi()
            .RequireAuthorization("ReportesLeer");
        }
    }
}