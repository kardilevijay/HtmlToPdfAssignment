using DinkToPdf;
using DinkToPdf.Contracts;
using PdfExportApp.Domain.Providers;

namespace PdfExportApp.DinkToPdfProvider.Implementations;

internal class HtmlToPdfConverter : IHtmlToPdfConverter
{
    private readonly IConverter _converter;

    public HtmlToPdfConverter(IConverter converter)
    {
        _converter = converter;
    }

    public async Task<byte[]> ConvertHtmlToPdf(string htmlContent)
    {
        var doc = ConstructPdfDocument(null, htmlContent);

        return await Task.FromResult(_converter.Convert(doc));
    }

    public async Task<byte[]> ConvertHtmlPageToPdf(string pageUrl)
    {
        var doc = ConstructPdfDocument(pageUrl, null);

        return await Task.FromResult(_converter.Convert(doc));
    }

    private static HtmlToPdfDocument ConstructPdfDocument(string? pageUrl, string? htmlContent) => new()
    {
        GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            },
        Objects =
            {
                new ObjectSettings()
                {
                    PagesCount = true,
                    WebSettings = { DefaultEncoding = "utf-8" },
                    FooterSettings =
                    {
                        FontSize = 10,
                        Right = "Page [page] of [toPage]",
                        Line = true,
                        Spacing = 2.812
                    },
                    UseLocalLinks = true,
                    UseExternalLinks = true,
                    ProduceForms = true,
                    Page = !string.IsNullOrWhiteSpace(pageUrl) ? pageUrl : null,
                    HtmlContent = !string.IsNullOrWhiteSpace(htmlContent) ? htmlContent : null
                }
            }
    };
}
