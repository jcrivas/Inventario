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
    public class InventarioController : Controller
    {
        //
        // GET: /Inventario/
        private brSucursal obrSucursal = new brSucursal();
        private brAlmacen obrAlmacen = new brAlmacen();
        private brProgramacionInventario obrProgramacionInventario = new brProgramacionInventario();

        public ActionResult Index()
        {
            List<beSucursal> listaSucursal = obrSucursal.Listar();
            var sucursales = new SelectList(listaSucursal.ToArray(), "idSucursal", "nombreSucursal");
            ViewBag.Sucursal = sucursales;

            return View(obrProgramacionInventario.Listar());
        }

        public JsonResult Filtro(string Descripcion, string Sucursal)
        {
            Int32 intSucursal = 0;
            if (String.IsNullOrEmpty(Sucursal))
                intSucursal = 0;
            else
                intSucursal = Int32.Parse(Sucursal);

            List<beProgramacionInventario> lbeProgramacionInventario = obrProgramacionInventario.Filtrar(Descripcion,intSucursal);
            TempData["NotaIngreso"] = lbeProgramacionInventario;

            JsonResult rpta = Json(lbeProgramacionInventario, JsonRequestBehavior.AllowGet);
            return rpta;
        }

        public ActionResult Editar(int id = 0)
        {
            List<beSucursal> listaSucursal = obrSucursal.Listar();
            var sucursales = new SelectList(listaSucursal.ToArray(), "idSucursal", "nombreSucursal");
            ViewBag.Sucursal = sucursales;

            List<beAlmacen> listaAlmacen = obrAlmacen.Listar();
            var almacenes = new SelectList(listaAlmacen.ToArray(), "idAlmacen", "nombreAlmacen");
            ViewBag.Almacen = almacenes;

            ViewBag.Mensaje = TempData["MENSAJE"];

            beProgramacionInventario registro = new beProgramacionInventario();
            if (id == 0)
            {
                registro.FechaInventarioTexto = DateTime.Now.ToShortDateString();
                registro.FechaRegistro = DateTime.Now;
            }
            else
            {
                registro = obrProgramacionInventario.ListarxID(id);
            }

            return View(registro);
        }

        public ActionResult Guardar(beProgramacionInventario obeProgramacionInventario)
        {
            if (String.IsNullOrEmpty(obeProgramacionInventario.DescripcionInventario))
                obeProgramacionInventario.DescripcionInventario = "";
            var r = obeProgramacionInventario.IdProgramacionInventario > 0 ?
                    obrProgramacionInventario.Actualizar(obeProgramacionInventario) :
                    obrProgramacionInventario.Insertar(obeProgramacionInventario);

            if (!r)
            {
                //    // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
                ViewBag.Mensaje = "Ocurrio un error al momento de grabar";
                TempData["MENSAJE"] = ViewBag.Mensaje;
                //return View("~/Views/Shared/_Mensajes.cshtml");
                return Redirect("~/Inventario/Editar");
            }
            else
            {
                ViewBag.Mensaje = "";
                TempData["MENSAJE"] = ViewBag.Mensaje;
            }

            return Redirect("~/Inventario/Index");
        }

        public ActionResult Delete(int id)
        {
            //int intNumero = Int32.Parse(NumeroNotaIngreso);
            obrProgramacionInventario.EliminarRegistro(id);
            //return View(lbeNotaIngreso);
            return Redirect("~/Inventario/Index");
        }
    }
}
