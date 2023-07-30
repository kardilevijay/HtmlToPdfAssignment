using Microsoft.Extensions.DependencyInjection;
using PdfExportApp.Domain.Services;

namespace PdfExportApp.Domain;

public static class Registrar
{
    public static void RegisterDomain(this IServiceCollection services)
    {
        services.AddTransient<IHtmlToPdfConversionService, HtmlToPdfConversionService>();
    }
}