using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ByS.Inventario.Entities;
using ByS.Inventario.Logic;
using WebByS.Models;

namespace WebByS.Controllers
{
    public class ProductoAlmacenarController : Controller
    {
        // GET: /ProductoAlmacenar/
        private brOrdenCompra obrOrdenCompra = new brOrdenCompra();
        private brNotaIngreso obrNotaIngreso = new brNotaIngreso();
        private brDetalleNotaIngreso obrDetalleNotaIngreso = new brDetalleNotaIngreso();
        private brKardex obrKardex = new brKardex();
        private brAlmacen obrAlmacen = new brAlmacen();

        public ActionResult Index()
        {
            List<beTipoDocumento> lbeTipoDocumento = new List<beTipoDocumento>();
            lbeTipoDocumento.Add(new beTipoDocumento("01","Orden de Compra"));
            lbeTipoDocumento.Add(new beTipoDocumento("02", "Nota de Ingreso"));
            var tipo = new SelectList(lbeTipoDocumento.ToArray(), "Codigo", "Descripcion");
            ViewBag.TipoDocumento = tipo;
            return View(obrOrdenCompra.ListarxAlmacenar());
        }

        public JsonResult Filtro(string FechaInicio, string FechaFin, string Tipo, string Numero)
        {
            FechaInicio = FechaInicio.Substring(6, 4) + FechaInicio.Substring(3, 2) + FechaInicio.Substring(0, 2);
            FechaFin = FechaFin.Substring(6, 4) + FechaFin.Substring(3, 2) + FechaFin.Substring(0, 2);
            if (String.IsNullOrEmpty(Numero))
                Numero = "";
            Int32 intTipo = 0;
            if (String.IsNullOrEmpty(Tipo))
                intTipo = 0;
            else
                intTipo = Int32.Parse(Tipo);

            List<beOrdenCompra> lbeOrdenCompra = obrOrdenCompra.FiltrarxAlmacenar(FechaInicio, FechaFin, Tipo, Numero);
            TempData["OrdenCompra"] = lbeOrdenCompra;

            JsonResult rpta = Json(lbeOrdenCompra, JsonRequestBehavior.AllowGet);
            return rpta;
        }

        public ActionResult InternarNI(int id)
        {
            ViewBag.NumeroDocumento = id;
            List<beAlmacen> listaAlmacen = obrAlmacen.Listar();
            var almacenes = new SelectList(listaAlmacen.ToArray(), "idAlmacen", "nombreAlmacen");
            ViewBag.Almacen = almacenes;
            return View(obrDetalleNotaIngreso.ListarxNota(id));
        }

        public ActionResult InternarOC(String id)
        {
            ViewBag.NumeroDocumento = id;
            List<beAlmacen> listaAlmacen = obrAlmacen.Listar();
            var almacenes = new SelectList(listaAlmacen.ToArray(), "idAlmacen", "nombreAlmacen");
            ViewBag.Almacen = almacenes;
            return View(obrOrdenCompra.ListarDetallexOrden(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InternarNotaIngreso(List<beDetalleNotaIngreso> listaDetalleNotaIngreso, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                String strAlmacen = form["IdAlmacen"].ToString();
                String strNumero = "";
                foreach (beDetalleNotaIngreso fila in listaDetalleNotaIngreso)
                {
                    beKardex obeKardex = new beKardex();
                    obeKardex.NumeroKardex = Int32.Parse(strAlmacen);
                    obeKardex.IdAlmacen = Int32.Parse(strAlmacen);
                    obeKardex.IdProducto = fila.IdProducto;
                    obeKardex.Observaciones = "";
                    obeKardex.SaldoActual = 0;
                    obeKardex.IdNotaIngreso = fila.NumeroNotaIngreso;
                    obeKardex.Fecha = DateTime.Now;
                    obeKardex.Ingreso = (int)fila.CantidadInternar;
                    obeKardex.CodigoCompra = "";
                    obeKardex.Cantidad = (int)fila.CantidadInternar;
                    obeKardex.Costo = 0;
                    obrKardex.Insertar(obeKardex);

                    //DETALLE DE KARDEX
                    beDetalleKardex obeDetalleKardex = new beDetalleKardex();
                    obeDetalleKardex.NumeroKardex = obeKardex.NumeroKardex;
                    obeDetalleKardex.NumeroDocumento = fila.NumeroNotaIngreso.ToString();
                    obeDetalleKardex.TipodeMovimiento = 1;
                    obeDetalleKardex.NumeroNotaIngreso = fila.NumeroNotaIngreso.ToString();
                    obeDetalleKardex.NumeroSalida = "";
                    obeDetalleKardex.Fecha = DateTime.Now;
                    obeDetalleKardex.Cantidad = (int)fila.CantidadInternar;

                    obrKardex.InsertarDetalle(obeDetalleKardex);

                    strNumero = fila.NumeroNotaIngreso.ToString();
                }
                //ACTUALIZAR ESTADO DE LA NOTA DE INGRESO
                beNotaIngreso obeNotaIngreso = new beNotaIngreso();
                obeNotaIngreso.NumeroNotaIngreso = Int32.Parse(strNumero);
                obeNotaIngreso.EstadoNotaIngreso = "I";
                obrNotaIngreso.ActualizarEstado(obeNotaIngreso);
            }
            //if (!r)
            //{
            //    // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
            //    ViewBag.Mensaje = "Ocurrio un error inesperado";
            //    return View("~/Views/Shared/_Mensajes.cshtml");
            //}
            return Redirect("~/ProductoAlmacenar/Index");
        }

        public ActionResult InternarOrdenCompra(List<beDetalleOrdenCompra> lbeDetalleOrdenCompra, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                String strAlmacen = form["IdAlmacen"].ToString();
                String strNumero = "";
                foreach (beDetalleOrdenCompra fila in lbeDetalleOrdenCompra)
                {
                    beKardex obeKardex = new beKardex();
                    obeKardex.NumeroKardex = Int32.Parse(strAlmacen);
                    obeKardex.IdAlmacen = Int32.Parse(strAlmacen);
                    obeKardex.IdProducto = fila.IdProducto;
                    obeKardex.Observaciones = "";
                    obeKardex.SaldoActual = 0;
                    obeKardex.Fecha = DateTime.Now;
                    obeKardex.Ingreso = (int)fila.CantidadInternar;
                    obeKardex.CodigoCompra = fila.nOrdenCompra;
                    obeKardex.Cantidad = (int)fila.CantidadInternar;
                    obeKardex.Costo = 0;
                    obrKardex.Insertar(obeKardex);

                    //DETALLE DE KARDEX
                    beDetalleKardex obeDetalleKardex = new beDetalleKardex();
                    obeDetalleKardex.NumeroKardex = obeKardex.NumeroKardex;
                    obeDetalleKardex.NumeroDocumento = fila.nOrdenCompra.ToString();
                    obeDetalleKardex.TipodeMovimiento = 1;
                    obeDetalleKardex.NumeroNotaIngreso = fila.nOrdenCompra.ToString();
                    obeDetalleKardex.NumeroSalida = "";
                    obeDetalleKardex.Fecha = DateTime.Now;
                    obeDetalleKardex.Cantidad = (int)fila.CantidadInternar;

                    obrKardex.InsertarDetalle(obeDetalleKardex);

                    strNumero = fila.nOrdenCompra;
                }
                //ACTUALIZAR ESTADO DE LA ORDEN DE COMPRA
                beOrdenCompra obeOrdenCompra = new beOrdenCompra();
                obeOrdenCompra.nOrdenCompra = strNumero;
                obeOrdenCompra.Estado = "I";
                obrOrdenCompra.ActualizarEstado(obeOrdenCompra);
            }
            //if (!r)
            //{
            //    // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
            //    ViewBag.Mensaje = "Ocurrio un error inesperado";
            //    return View("~/Views/Shared/_Mensajes.cshtml");
            //}
            return Redirect("~/ProductoAlmacenar/Index");
        }
    }
}
