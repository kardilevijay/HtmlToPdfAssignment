namespace PdfExportApp.Domain.Providers;

public interface IHtmlToPdfConverter
{
    Task<byte[]> ConvertHtmlPageToPdf(string pageUrl);
    Task<byte[]> ConvertHtmlToPdf(string htmlContent);
}
