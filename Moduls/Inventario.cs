using System;
using System.Collections.Generic;

namespace LIstaProductos.Moduls;

public partial class Inventario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Precio { get; set; }

    public int Cantidad { get; set; }
}
