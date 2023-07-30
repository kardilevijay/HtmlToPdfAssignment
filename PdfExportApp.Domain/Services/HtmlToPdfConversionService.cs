using PdfExportApp.Domain.Providers;

namespace PdfExportApp.Domain.Services;

internal class HtmlToPdfConversionService : IHtmlToPdfConversionService
{
    private readonly IHtmlToPdfConverter _htmlToPdfConverter;

    public HtmlToPdfConversionService(IHtmlToPdfConverter htmlToPdfConverter)
    {
        _htmlToPdfConverter = htmlToPdfConverter;
    }

    public async Task<byte[]> ConvertHtmlPageToPdf(string pageUrl)
    {
        return await _htmlToPdfConverter.ConvertHtmlPageToPdf(pageUrl);
    }

    public async Task<byte[]> ConvertHtmlToPdf(string htmlContent)
    {
        return await _htmlToPdfConverter.ConvertHtmlToPdf(htmlContent);
    }
}
