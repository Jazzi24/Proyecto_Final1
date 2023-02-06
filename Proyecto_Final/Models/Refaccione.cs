using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models;

public partial class Refaccione
{
    public int IdRefaccion { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Marca { get; set; }

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Cantidad { get; set; }
}
