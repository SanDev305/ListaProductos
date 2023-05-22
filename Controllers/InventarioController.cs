using LIstaProductos.Models;
using LIstaProductos.Models.Request;
using LIstaProductos.Models.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIstaProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using(ProductosContext db = new ProductosContext())
                {
                    var lst = db.Inventario.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Post(InventarioRequest oInventario)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ProductosContext db = new ProductosContext())
                {
                    Inventario inventario = new Inventario();                     
                    inventario.Nombre = oInventario.Nombre;
                    inventario.Precio = oInventario.Precio;
                    inventario.Cantidad = oInventario.Cantidad;
                    db.Inventario.Add(inventario);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Update(InventarioRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ProductosContext db = new ProductosContext())
                {
                    Inventario oInvent = db.Inventario.Find(oModel.Id);
                    oInvent.Nombre = oModel.Nombre;
                    oInvent.Precio = oModel.Precio;
                    oInvent.Cantidad = oModel.Cantidad;
                    db.Entry(oInvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }                
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message; 
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (ProductosContext db = new ProductosContext())
                {
                    Inventario oInvent = db.Inventario.Find(Id);
                    db.Remove(oInvent);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
