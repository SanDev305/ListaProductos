using System;
using System.Collections.Generic;

namespace LIstaProductos.Models;

public partial class Inventario
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int Precio { get; set; }

    public int Cantidad { get; set; }
}
