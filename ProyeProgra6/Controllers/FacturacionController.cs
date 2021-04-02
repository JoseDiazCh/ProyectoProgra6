using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class FacturacionController : Controller
    {
        //conexxion a la base datos
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        // GET: Facturacion
        public ActionResult EncabezadoFac()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RetornaListaFactura()
        {
            List<sp_RetornaFacturaEnc_Result> lista =
               this.modeloBD.sp_RetornaFacturaEnc(" ").ToList();
            return Json(new
            {
                resultado = lista
            });
        }

        //------------------------------------------------------------------------------------//
        /// <summary>
        /// INSERTA la nueva persona
        /// </summary>
        /// <returns></returns>

        public ActionResult FacturaNueva()
        {
            this.AgregaUsuariosViewBag();
            this.AgregaVehiculoViewBag();
            return View();
        }

        void AgregaUsuariosViewBag()
        {
            this.ViewBag.ListaUsuarios =
                    this.modeloBD.sp_RetornaUsuarios(null," ").ToList();
        }

        void AgregaVehiculoViewBag()
        {
            this.ViewBag.ListaVehiculos =
                    this.modeloBD.sp_RetornaVehiculos(" ").ToList();
        }
            /// <summary>
            /// este INSERTA la persona nueva tipo HttpPost
            /// </summary>
            /// <returns></returns>
            [HttpPost]
        public ActionResult FacturaNueva(sp_RetornaFacturaEnc_Result modeloVista)
        {
            ///registra cantidad de registros afectados.
            ///
            int cantRegistrosafectados = 0;
            string resultado = "";

            try
            {

                cantRegistrosafectados =
                    this.modeloBD.sp_InsertaFactura(
                        modeloVista.idUsuario,
                        modeloVista.idVehiculo,
                        modeloVista.Fecha,
                        modeloVista.MontoTotalServicio,
                        modeloVista.Column1
                      
                        );
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error:" + error.Message;

            }
            finally
            {
                if (cantRegistrosafectados > 0)
                {
                    resultado = "Registro insertado";

                }
                else
                {
                    resultado += ".No se Pudo insertar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            this.AgregaUsuariosViewBag();
            this.AgregaVehiculoViewBag();
            return View();
        }
    }
}