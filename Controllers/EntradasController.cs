using EntradasMvc.Models;
using EntradasMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntradasMvc.Controllers;

public class EntradasController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        CargarTiposDeEntrada();

        var viewModel = new CotizacionInputViewModel();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calcular(CotizacionInputViewModel viewModel)
    {
        CargarTiposDeEntrada();

        if (!ModelState.IsValid)
        {
            return View("Index", viewModel);
        }

        // 1. ENTRADA -> 2. NEGOCIO
        var cotizacion = new Cotizacion
        {
            Cliente = viewModel.Cliente,
            Cantidad = viewModel.Cantidad
        };

        // 2. NEGOCIO -> 3. PRESENTACION
        var resultadoViewModel = new ResultadoCotizacionViewModel
        {
            Cotizacion = cotizacion,
            Evento = "Concierto Web III",
            FechaEvento = new DateTime(2026, 11, 15),
            TipoEntrada = viewModel.TipoEntrada,
            Mensaje = "Gracias por realizar su cotización."
        };

        return View("Resultado", resultadoViewModel);
    }

    // Las opciones del selector se construyen tanto en el GET como en el POST,
    // porque cada solicitud crea una instancia nueva del controlador.
    private void CargarTiposDeEntrada()
    {
        ViewBag.TiposDeEntrada = new List<SelectListItem>
        {
            new() { Value = "General", Text = "General" },
            new() { Value = "VIP", Text = "VIP" }
        };
    }
}
