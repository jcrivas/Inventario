using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ByS.Inventario.Entities;
using ByS.Inventario.Logic;

namespace WebByS.Controllers
{
    public class NotaIngresoController : Controller
    {
        //
        // GET: /NotaIngreso/
        private brNotaIngreso obrNotaIngreso = new brNotaIngreso();
        private brDetalleNotaIngreso obrDetalleNotaIngreso = new brDetalleNotaIngreso();
        private brProducto obrProducto = new brProducto();
        private brProveedor obrProveedor = new brProveedor();
        private brAlmacen obrAlmacen = new brAlmacen();
        private brEmpleado obrEmpleado = new brEmpleado();

        public ActionResult Index()
        {
            //brNotaIngreso obrNotaIngreso = new brNotaIngreso();
            List<beNotaIngreso> lbeNotaIngreso = obrNotaIngreso.Listar();
            TempData["NotaIngreso"] = lbeNotaIngreso;
            List<beAlmacen> listaAlmacen = obrAlmacen.Listar();
            var almacenes = new SelectList(listaAlmacen.ToArray(), "idAlmacen", "nombreAlmacen");
            ViewBag.Almacen = almacenes;

            List<beProveedor> listaProveedor = obrProveedor.Listar();
            var proveedores = new SelectList(listaProveedor.ToArray(), "idProveedor", "nombreProveedor");
            ViewBag.Proveedor = proveedores;

            ViewBag.Mensaje = TempData["MENSAJE"];

            return View(lbeNotaIngreso);
        }

        public JsonResult Filtro(string FechaInicio, string FechaFin, string Numero, string Proveedor)
        {
            FechaInicio = FechaInicio.Substring(6, 4) + FechaInicio.Substring(3, 2) + FechaInicio.Substring(0, 2);
            FechaFin = FechaFin.Substring(6, 4) + FechaFin.Substring(3, 2) + FechaFin.Substring(0, 2);
            Int32 intNumero = 0;
            if (String.IsNullOrEmpty(Numero)) 
                intNumero = 0;
            else
                intNumero = Int32.Parse(Numero);
            Int32 intProveedor = 0;
            if (String.IsNullOrEmpty(Proveedor))
                intProveedor = 0;
            else
                intProveedor = Int32.Parse(Proveedor);

            List<beNotaIngreso> lbeNotaIngreso = obrNotaIngreso.Filtrar(FechaInicio, FechaFin, intNumero, intProveedor);
            TempData["NotaIngreso"] = lbeNotaIngreso;

            JsonResult rpta = Json(lbeNotaIngreso, JsonRequestBehavior.AllowGet);
            return rpta;
        }

        public ActionResult Editar(int id = 0)
        {
            List<beProveedor> listaProveedor = obrProveedor.Listar();
            ViewBag.DetalleNotaIngreso = obrDetalleNotaIngreso.ListarxNota(id);
            beNotaIngreso obeNotaIngeso = new beNotaIngreso();
            obeNotaIngeso.IdAlmacen = 0;
            var proveedores = new SelectList(listaProveedor.ToArray(), "idProveedor", "nombreProveedor");
            List<beAlmacen> listaAlmacen = obrAlmacen.Listar();
            var almacenes = new SelectList(listaAlmacen.ToArray(), "idAlmacen", "nombreAlmacen");
            List<beEmpleadoRH> listaSupervisor = obrEmpleado.Listar();
            var supervisores = new SelectList(listaSupervisor.ToArray(), "codEmpleado", "nombreCompleto");
            
            ViewBag.Proveedor = proveedores;
            ViewBag.Almacen = almacenes;
            ViewBag.Supervisor = supervisores;

            ViewBag.Mensaje = TempData["MENSAJE"];

            beNotaIngreso registro = new beNotaIngreso();
            if (id == 0)
            {
                registro.Fecha = DateTime.Now;
                registro.IdEmpleado = 2;
                registro.EstadoNotaIngreso = "G";
            }
            else
            {
                registro = obrNotaIngreso.ListarxID(id);
            }
            registro.FechaFormateada = registro.Fecha.ToShortDateString();

            return View(registro);
        }

        public ActionResult EditarCantidad(int id, int idProducto)
        {
            beDetalleNotaIngreso fila = obrDetalleNotaIngreso.ListarxNotaProducto(id, idProducto);
            if (fila.NumeroNotaIngreso == 0)
            {
                fila.NumeroNotaIngreso = id;
                fila.IdProducto = idProducto;
                fila.NombreProducto = obrProducto.ListarxId(idProducto).Descripcion;
            }
            return View(fila);
        }

        public ActionResult Items(int id)
        {
            ViewBag.Producto = obrProducto.Listar();
            ViewBag.NotaIngresoID = id;
            return View(obrDetalleNotaIngreso.ListarxNota(id));
        }

        public ActionResult Guardar(beNotaIngreso obeNotaIngreso)
        {
            if (String.IsNullOrEmpty(obeNotaIngreso.Observaciones))
                obeNotaIngreso.Observaciones = "";
            bool bNuevo = false;
            if (obeNotaIngreso.NumeroNotaIngreso == 0)
                bNuevo = true;
            var r = obeNotaIngreso.NumeroNotaIngreso > 0 ?
                    obrNotaIngreso.Actualizar(obeNotaIngreso) :
                    obrNotaIngreso.Insertar(obeNotaIngreso);

            if (!r)
            {
                //    // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
                ViewBag.Mensaje = "Error al momento de grabar";
                TempData["MENSAJE"] = ViewBag.Mensaje;
                //return View("~/Views/Shared/_Mensajes.cshtml");
                return Redirect("~/NotaIngreso/Editar");
            }
            else
            {
                if (obeNotaIngreso.NumeroNotaIngreso > 0)
                {
                    if (bNuevo)
                        ViewBag.Mensaje = "Se generó Nota de Ingreso N° " + obeNotaIngreso.NumeroNotaIngreso.ToString();
                    else
                        ViewBag.Mensaje = "Se actualizó Nota de Ingreso N° " + obeNotaIngreso.NumeroNotaIngreso.ToString();
                    TempData["MENSAJE"] = ViewBag.Mensaje;
                    return Redirect("~/NotaIngreso/Editar/" + obeNotaIngreso.NumeroNotaIngreso.ToString());
                }
                else
                {
                    ViewBag.Mensaje = "Se generó Nota de Ingreso N° " + obeNotaIngreso.NumeroNotaIngreso.ToString();
                    TempData["MENSAJE"] = ViewBag.Mensaje;
                }
            }
            
            return Redirect("~/NotaIngreso/Index");
        }

        public ActionResult GuardarCantidad(beDetalleNotaIngreso obeDetalleNotaIngreso)
        {
            var r = obrDetalleNotaIngreso.ActualizarCantidad(obeDetalleNotaIngreso);

            //if (!r)
            //{
            //    // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
            //    ViewBag.Mensaje = "Ocurrio un error inesperado";
            //    return View("~/Views/Shared/_Mensajes.cshtml");
            //}

            return Redirect("~/NotaIngreso/Editar/" + obeDetalleNotaIngreso.NumeroNotaIngreso.ToString());
        }

        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            //int intNumero = Int32.Parse(NumeroNotaIngreso);
            obrNotaIngreso.EliminarRegistro(id);
            //return View(lbeNotaIngreso);
            ViewBag.Mensaje = "Se anuló Nota de Ingreso N° " + id.ToString();
            TempData["MENSAJE"] = ViewBag.Mensaje;
            return Redirect("~/NotaIngreso/Index");
        }

        public ActionResult DeleteProducto(int id, int idProducto)
        {
            beDetalleNotaIngreso obeDetalleNotaIngreso = new beDetalleNotaIngreso();
            obeDetalleNotaIngreso.NumeroNotaIngreso = id;
            obeDetalleNotaIngreso.IdProducto = idProducto;
            obrDetalleNotaIngreso.EliminarProducto(obeDetalleNotaIngreso);
            //return View(lbeNotaIngreso);
            return Redirect("~/NotaIngreso/Editar/" + id.ToString());
        }

        public ActionResult ActualizarCantidad(int id, int idProducto,Decimal Cantidad)
        {
            beDetalleNotaIngreso obeDetalleNotaIngreso = new beDetalleNotaIngreso();
            obeDetalleNotaIngreso.NumeroNotaIngreso = id;
            obeDetalleNotaIngreso.IdProducto = idProducto;
            obeDetalleNotaIngreso.Cantidad = Cantidad;
            obrDetalleNotaIngreso.ActualizarCantidad(obeDetalleNotaIngreso);
            //return View(lbeNotaIngreso);
            return Redirect("~/NotaIngreso/Items/" + id.ToString());
        }

        //[HttpDelete]
        //public PartialViewResult Delete(string notaIngresoId)
        //{
        //    brNotaIngreso obrNotaIngreso = new brNotaIngreso();
        //    int intNumero = Int32.Parse(notaIngresoId);
        //    obrNotaIngreso.EliminarRegistro(intNumero);
        //    List<beNotaIngreso> lbeNotaIngreso = obrNotaIngreso.Listar();
        //    TempData["NotaIngreso"] = lbeNotaIngreso;
        //    return PartialView("Tabla",lbeNotaIngreso);
        //}
    }
}
