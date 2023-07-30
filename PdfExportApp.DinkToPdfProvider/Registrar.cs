using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using PdfExportApp.DinkToPdfProvider.Implementations;
using PdfExportApp.Domain.Providers;

namespace PdfExportApp.DinkToPdfProvider;

public static class Registrar
{
    public static void RegisterDinkToPdfProvider(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        services.AddTransient<IHtmlToPdfConverter, HtmlToPdfConverter>();
    }
}