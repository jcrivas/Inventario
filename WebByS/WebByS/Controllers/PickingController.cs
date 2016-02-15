using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ByS.Inventario.Entities;
using ByS.Inventario.Logic;

namespace WebByS.Controllers
{
    public class PickingController : Controller
    {
        //
        // GET: /Picking/
        private brSucursal obrSucursal = new brSucursal();
        private brPedido obrPedido = new brPedido();
        private brEmpleado obrEmpleado = new brEmpleado();
        private brProgramacionPicking obrProgramacionPicking = new brProgramacionPicking();

        public ActionResult Index()
        {
            List<beSucursal> listaSucursal = obrSucursal.Listar();
            var sucursales = new SelectList(listaSucursal.ToArray(), "idSucursal", "nombreSucursal");
            ViewBag.Sucursal = sucursales;

            List<beEmpleadoRH> listaEmpleado = obrEmpleado.Listar();
            var empleados = new SelectList(listaEmpleado.ToArray(), "codEmpleado", "nombreCompleto");
            ViewBag.Empleado = empleados;

            List<bePedido> lbePedido = obrPedido.ListarPendientePicking();
            TempData["ListaPedido"] = lbePedido;
            return View(lbePedido);
        }

        public ActionResult Listado()
        {
            return View(obrProgramacionPicking.Listar());
        }

        public ActionResult Detalle(int id)
        {
            ViewBag.Detalle = obrProgramacionPicking.ListarDetallexPicking(id);
            return View(obrProgramacionPicking.ListarxID(id));
        }
        //public JsonResult Filtro(string PedidoInicio, string PedidoFin, string Sucursal)
        //{
        //    List<bePedido> lbePedido = (List<bePedido>)TempData["ListaPedido"];
        //    TempData["ListaPedido"] = lbePedido;

        //    JsonResult rpta = Json(lbePedido, JsonRequestBehavior.AllowGet);
        //    return rpta;
        //}

        public ActionResult Filtrar(string PedidoInicio, string PedidoFin, string Sucursal)
        {
            List<bePedido> lbePedido = (List<bePedido>)TempData["ListaPedido"];
            TempData["ListaPedido"] = lbePedido;

            //JsonResult rpta = Json(lbePedido, JsonRequestBehavior.AllowGet);
            return View(lbePedido);
        }

        public ActionResult ProgramarPicking(List<bePedido> lbePedidoFiltro)
        {
            List<beSucursal> listaSucursal = obrSucursal.Listar();
            var sucursales = new SelectList(listaSucursal.ToArray(), "idSucursal", "nombreSucursal");
            ViewBag.Sucursal = sucursales;

            List<beEmpleadoRH> listaEmpleado = obrEmpleado.Listar();
            var empleados = new SelectList(listaEmpleado.ToArray(), "codEmpleado", "nombreCompleto");
            ViewBag.Empleado = empleados;

            TempData["ListaPedido"] = lbePedidoFiltro;
            return View(lbePedidoFiltro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProgramarPicking(FormCollection form, List<bePedido> lbePedido, String submitButton)
        {
            switch (submitButton)
            {
                case "Grabar":
                    if (ModelState.IsValid)
                    {
                        String strEmpleado = form["IdEmpleado"].ToString();
                        String strFecha = form["txtFecha"].ToString();
                        String strDescripcion = "";
                        String strTurno = "";
                        foreach (bePedido fila in lbePedido)
                        {
                            if (fila.Seleccionado)
                            {
                                beProgramacionPicking obeProgramacionPicking = new beProgramacionPicking();
                                obeProgramacionPicking.IdProgramacionPicking = 0;
                                obeProgramacionPicking.IdEmpleado = Int32.Parse(strEmpleado);
                                obeProgramacionPicking.Descripcion = strDescripcion;
                                obeProgramacionPicking.Fecha = DateTime.Parse(strFecha);
                                obeProgramacionPicking.Turno = strTurno;
                                obeProgramacionPicking.NumeroPedido = fila.NumeroPedido;

                                obrProgramacionPicking.Insertar(obeProgramacionPicking);

                                //ACTUALIZAR ESTADO DEL PEDIDO
                                bePedido obePedido = new bePedido();
                                obePedido.NumeroPedido = fila.NumeroPedido;
                                obePedido.Estado = 1;
                                obrPedido.ActualizarEstado(obePedido);
                            }
                        }

                    }
                    return Redirect("~/Picking/Index");
                case "Buscar":
                    String strSucursal = form["IdSucursal"].ToString();
                    String strPedidoInicio = form["txtPedidoInicio"].ToString();
                    String strPedidoFin = form["txtPedidoFin"].ToString();
                    
                    int intSucursal = 0;
                    if (String.IsNullOrEmpty(strSucursal))
                        intSucursal = 0;
                    else
                        intSucursal = Int32.Parse(strSucursal);
                    List<bePedido> lbePedidoFiltro = obrPedido.Filtrar(strPedidoInicio, strPedidoFin, intSucursal);
                    TempData["ListaPedido"] = lbePedidoFiltro;

                    List<beSucursal> listaSucursal = obrSucursal.Listar();
                    var sucursales = new SelectList(listaSucursal.ToArray(), "idSucursal", "nombreSucursal");
                    ViewBag.Sucursal = sucursales;

                    List<beEmpleadoRH> listaEmpleado = obrEmpleado.Listar();
                    var empleados = new SelectList(listaEmpleado.ToArray(), "codEmpleado", "nombreCompleto");
                    ViewBag.Empleado = empleados;

                    return View(lbePedidoFiltro );
                default:
                    return (View());
            }
        }

        public ActionResult PickarPedido()
        {
            List<beProgramacionPicking> lbeProgramacionPicking = obrProgramacionPicking.ListarPickar();
            TempData["ListaPickar"] = lbeProgramacionPicking;
            return View(lbeProgramacionPicking);
        }

        public ActionResult FiltroPickar(string NumeroPedido)
        {
            List<beProgramacionPicking> lbeProgramacionPicking = obrProgramacionPicking.ListarPickarFiltro(NumeroPedido);
            //List<bePedido> lbePedido = (List<bePedido>)TempData["ListaPedido"];
            //TempData["ListaPedido"] = lbePedido;

            JsonResult rpta = Json(lbeProgramacionPicking, JsonRequestBehavior.AllowGet);
            return rpta;
        }

        public ActionResult Pickar(string Id)
        {
            List<beDetalleProgramacionPicking> lbeDetalleProgramacionPicking = obrProgramacionPicking.ListarDetallexPedido(Id);
            ViewBag.ListaProducto = lbeDetalleProgramacionPicking;
            bePedido obePedido = obrPedido.ListarPickarxPedido(Id);
            return View(obePedido);
        }

        public ActionResult Atender(int PickingId, string pedidoId, int productoId)
        {
            beDetalleProgramacionPicking obeDetalleProgramacionPicking = obrProgramacionPicking.ListarDetallexID(PickingId,pedidoId,productoId);
            return View(obeDetalleProgramacionPicking);
        }

        public ActionResult GuardarCantidad(beDetalleProgramacionPicking obeDetalleProgramacionPicking)
        {
            var r = obrProgramacionPicking.ActualizarDetalleCantidad(obeDetalleProgramacionPicking);

            //if (!r)
            //{
            //    // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
            //    ViewBag.Mensaje = "Ocurrio un error inesperado";
            //    return View("~/Views/Shared/_Mensajes.cshtml");
            //}

            return Redirect("~/Picking/Pickar/" + obeDetalleProgramacionPicking.NumeroPedido.Trim());
        }
    }
}
