using Microsoft.AspNetCore.Mvc;
using PdfExportApp.Domain.Services;
using PdfExportApp.Models;

namespace PdfExportApp.Controllers;

public class HomeController : Controller
{
    private readonly IHtmlToPdfConversionService _htmlToPdfConversionService;

    public HomeController(IHtmlToPdfConversionService htmlToPdfConversionService)
    {
        _htmlToPdfConversionService = htmlToPdfConversionService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GeneratePdf([FromBody] GeneratePdfRequestViewModel request)
    {
        if (string.IsNullOrWhiteSpace(request?.HtmlContent))
        {
            return BadRequest("HtmlContent is required");
        }

        var pdf = await _htmlToPdfConversionService.ConvertHtmlToPdf(request.HtmlContent);
        return File(pdf, "application/pdf", "exported_file.pdf");
    }
}