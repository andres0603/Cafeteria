using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using lib_cafeteria.modelos;

namespace Lib_presentaciones.Configuraciones
{
    public class ReportePedidos
    {
        public static byte[] Generar(List<pedidos> lista)
        {
            using var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            var fuenteNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var fuenteNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            // Título
            document.Add(new Paragraph("REPORTE DE PEDIDOS")
                .SetFontSize(18)
                .SetFont(fuenteNegrita)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph($"Fecha: {DateTime.Now:yyyy-MM-dd HH:mm}")
                .SetFontSize(10)
                .SetFont(fuenteNormal)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph("\n"));

            foreach (var pedido in lista)
            {
                // Encabezado del pedido
                document.Add(new Paragraph($"Pedido #{pedido.id}")
                    .SetFontSize(13)
                    .SetFont(fuenteNegrita));

                document.Add(new Paragraph($"Cliente: {pedido._clientes?.nombre}   |   Estado: {pedido._estadosPedido?.nombre}   |   Total: ${pedido.total:N0}")
                    .SetFontSize(10)
                    .SetFont(fuenteNormal));

                if (!string.IsNullOrEmpty(pedido.notasParaCocina))
                    document.Add(new Paragraph($"Notas: {pedido.notasParaCocina}")
                        .SetFontSize(10)
                        .SetFont(fuenteNormal));

                // Tabla de detalles
                if (pedido.detalles != null && pedido.detalles.Count > 0)
                {
                    var tabla = new Table(new float[] { 3, 1, 1, 1, 2 })
                        .UseAllAvailableWidth();

                    // Encabezados tabla
                    foreach (var encabezado in new[] { "Producto", "Cantidad", "Extra", "Cant. Extra", "Subtotal" })
                    {
                        tabla.AddHeaderCell(new Cell()
                            .Add(new Paragraph(encabezado).SetFont(fuenteNegrita))
                            .SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                    }

                    // Filas
                    foreach (var detalle in pedido.detalles)
                    {
                        tabla.AddCell(new Paragraph(detalle._producto?.nombre ?? "").SetFont(fuenteNormal));
                        tabla.AddCell(new Paragraph(detalle.cantidad.ToString()).SetFont(fuenteNormal));
                        tabla.AddCell(new Paragraph(detalle._productoExtra?.nombre ?? "N/A").SetFont(fuenteNormal));
                        tabla.AddCell(new Paragraph(detalle.cantidadExtra.ToString()).SetFont(fuenteNormal));
                        tabla.AddCell(new Paragraph($"${detalle.subtotal:N0}").SetFont(fuenteNormal));
                    }

                    document.Add(tabla);
                }

                document.Add(new Paragraph("\n"));
            }

            document.Close();
            return ms.ToArray();
        }
    }
}