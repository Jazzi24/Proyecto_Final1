using System;
using System.Collections.Generic;

namespace Proyecto_Final.Models;

public partial class Auto
{
    public int IdAuto { get; set; }

    public string Modelo { get; set; } = null!;

    public string? Color { get; set; }

    public decimal Precio { get; set; }

    public decimal? Cantidad { get; set; }
}
