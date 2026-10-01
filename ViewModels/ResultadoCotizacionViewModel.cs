using EntradasMvc.Models;

namespace EntradasMvc.ViewModels;

public class ResultadoCotizacionViewModel
{
    public Cotizacion Cotizacion { get; set; } = new();

    public string Evento { get; set; } = string.Empty;

    public DateTime FechaEvento { get; set; }

    public string TipoEntrada { get; set; } = string.Empty;

    public string Mensaje { get; set; } = string.Empty;
}
