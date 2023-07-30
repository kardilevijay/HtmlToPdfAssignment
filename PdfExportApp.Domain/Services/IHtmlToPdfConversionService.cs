using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfExportApp.Domain.Services;

public interface IHtmlToPdfConversionService
{
    Task<byte[]> ConvertHtmlPageToPdf(string pageUrl);
    Task<byte[]> ConvertHtmlToPdf(string htmlContent);
}
