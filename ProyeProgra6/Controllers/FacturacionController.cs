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
            return View();
        }

        public ActionResult RetornaUsuario()
        {
            List<sp_RetornaUsuarios_Result> usuario =
               this.modeloBD.sp_RetornaUsuarios(null,null).ToList();
            return Json(usuario);
        }
        public ActionResult RetornaVehiculo()
        {
            List<sp_RetornaVehiculos_Result> vehiculo =
               this.modeloBD.sp_RetornaVehiculos(null).ToList();
            return Json(vehiculo);

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
                        modeloVista.EstadoFactura
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
         
            return View();
        }
    }
}