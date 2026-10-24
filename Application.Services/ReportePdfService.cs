using DTOs;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.SkiaSharp;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Application.Services
{
    public class ReportePdfService
    {
        public byte[] GenerarReporteAlquileres(List<ReporteAlquileresDTO> datos, DateTime fechaDesde, DateTime fechaHasta)
        {
            int total = datos.Sum(d => d.CantidadAlquileres);

            var sinAlquileres = datos
                .GroupBy(d => d.Sucursal)
                .Where(g => g.Sum(d => d.CantidadAlquileres) == 0)
                .Select(g => g.Key)
                .ToList();

            // Solo hay grafico si hubo alquileres
            byte[]? grafico = total > 0 ? CrearGrafico(datos) : null;

            return Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Margin(30);
                    pagina.DefaultTextStyle(x => x.FontSize(11));

                    pagina.Header().Text("Reporte de alquileres").Bold().FontSize(20);

                    pagina.Content().Column(columna =>
                    {
                        columna.Spacing(15);

                        columna.Item().Text($"Período: {fechaDesde:dd/MM/yyyy} al {fechaHasta:dd/MM/yyyy}");

                        if (grafico != null)
                            columna.Item().Image(grafico).FitWidth();
                        else
                            columna.Item().Text("No se encontraron alquileres en el período seleccionado.").Italic();

                        if (sinAlquileres.Count > 0)
                            columna.Item().Text($"Sin alquileres en el período: {string.Join(", ", sinAlquileres)}.");

                        columna.Item().Text("Se excluyen los alquileres cancelados.");
                        columna.Item().Text($"Total de alquileres: {total}");
                        columna.Item().Text($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    });

                    pagina.Footer().AlignCenter().Text(texto =>
                    {
                        texto.Span("Página ");
                        texto.CurrentPageNumber();
                    });
                });
            }).GeneratePdf();
        }
        private byte[] CrearGrafico(List<ReporteAlquileresDTO> datos)
        {
            var meses = datos
                .Select(d => new DateTime(d.Anio, d.Mes, 1))
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            var sucursales = datos
                .Select(d => new { d.SucursalId, d.Sucursal })
                .Distinct()
                .OrderBy(s => s.Sucursal)
                .ToList();

            var colores = new[] { OxyColors.SeaGreen, OxyColors.Goldenrod, OxyColors.IndianRed, OxyColors.SteelBlue };

            var grafico = new PlotModel { Title = "Cantidad de alquileres por mes y sucursal" };

            grafico.Legends.Add(new Legend
            {
                LegendPosition = LegendPosition.BottomCenter,
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Horizontal
            });

            var ejeMeses = new CategoryAxis { Position = AxisPosition.Bottom, Key = "Meses", GapWidth = 0.2 };
            foreach (var mes in meses)
                ejeMeses.Labels.Add(mes.ToString("MMM yy"));
            grafico.Axes.Add(ejeMeses);

            grafico.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Key = "Cantidad",
                Title = "Cantidad de alquileres",
                Minimum = 0,
                MinimumMajorStep = 1,
                StringFormat = "0"
            });

            double ancho = 0.8 / sucursales.Count;

            for (int i = 0; i < sucursales.Count; i++)
            {
                var serie = new RectangleBarSeries
                {
                    Title = sucursales[i].Sucursal,
                    XAxisKey = "Meses",
                    YAxisKey = "Cantidad",
                    FillColor = colores[i % colores.Length],
                    StrokeColor = OxyColors.Black,
                    StrokeThickness = 1
                };

                for (int j = 0; j < meses.Count; j++)
                {
                    var cantidad = datos
                        .Where(d => d.Anio == meses[j].Year && d.Mes == meses[j].Month && d.SucursalId == sucursales[i].SucursalId)
                        .Sum(d => d.CantidadAlquileres);

                    if (cantidad > 0)
                    {
                        double x = j - 0.4 + i * ancho;
                        serie.Items.Add(new RectangleBarItem(x, 0, x + ancho, cantidad));
                    }
                }

                grafico.Series.Add(serie);
            }

            // para exportar a imagen
            using var imagen = new MemoryStream();
            new PngExporter { Width = 1600, Height = 800 }.Export(grafico, imagen);
            return imagen.ToArray();
        }

        public byte[] GenerarReporteTop10Bicicletas(List<ReporteRankingBicicletaDTO> datos, int anio)
        {
            return Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Margin(30);
                    pagina.DefaultTextStyle(x => x.FontSize(11));

                    // Encabezado
                    pagina.Header().Column(col =>
                    {
                        col.Item().Text("Top 10 - Bicicletas más alquiladas").Bold().FontSize(20);
                        col.Item().Text($"Año analizado: {anio}").FontSize(12).FontColor(Colors.Grey.Darken1);
                    });

                    // Contenido
                    pagina.Content().PaddingTop(15).Column(columna =>
                    {
                        columna.Spacing(15);

                        if (datos.Count == 0)
                        {
                            columna.Item().Text($"No se registraron alquileres de bicicletas en el año {anio}.").Italic();
                        }
                        else
                        {
                            columna.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columnas =>
                                {
                                    columnas.ConstantColumn(45);  // #
                                    columnas.ConstantColumn(50);  // ID
                                    columnas.RelativeColumn(3);   // Marca
                                    columnas.RelativeColumn(3);   // Modelo
                                    columnas.RelativeColumn(2);   // Cantidad
                                });

                                // Encabezados de tabla
                                tabla.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten2).Padding(6).BorderBottom(1).BorderColor(Colors.Grey.Darken1).AlignCenter().Text("#").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten2).Padding(6).BorderBottom(1).BorderColor(Colors.Grey.Darken1).AlignCenter().Text("ID").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten2).Padding(6).BorderBottom(1).BorderColor(Colors.Grey.Darken1).Text("Marca").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten2).Padding(6).BorderBottom(1).BorderColor(Colors.Grey.Darken1).Text("Modelo").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten2).Padding(6).BorderBottom(1).BorderColor(Colors.Grey.Darken1).AlignRight().Text("Veces alquilada").Bold();
                                });

                                // Filas
                                for (int i = 0; i < datos.Count; i++)
                                {
                                    var fila = datos[i];
                                    var colorFondo = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                                    tabla.Cell().Background(colorFondo).Padding(6).BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).AlignCenter().Text($"{fila.Puesto}°");
                                    tabla.Cell().Background(colorFondo).Padding(6).BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).AlignCenter().Text(fila.IdBicicleta.ToString());
                                    tabla.Cell().Background(colorFondo).Padding(6).BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Text(fila.Marca);
                                    tabla.Cell().Background(colorFondo).Padding(6).BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Text(fila.Modelo);
                                    tabla.Cell().Background(colorFondo).Padding(6).BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).AlignRight().Text(fila.CantAlquileres.ToString()).Bold();
                                }
                            });
                        }

                        columna.Item().Text("Se excluyen los alquileres cancelados.");
                        columna.Item().Text($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    });

                    // Pie de página
                    pagina.Footer().AlignCenter().Text(texto =>
                    {
                        texto.Span("Página ");
                        texto.CurrentPageNumber();
                    });
                });
            }).GeneratePdf();
        }

    }
}