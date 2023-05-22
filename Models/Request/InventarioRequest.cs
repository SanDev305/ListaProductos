namespace LIstaProductos.Models.Request
{
    public class InventarioRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
