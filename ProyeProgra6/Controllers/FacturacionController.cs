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
               this.modeloBD.sp_RetornaFacturaEnc("").ToList();
            return Json(new
            {
                resultado = lista
            });
        }

        //------------------------------------------------------------------------------------//
        /// <summary>
        /// INSERTA la nueva factura
        /// </summary>
        /// <returns></returns>

        public ActionResult FacturaNueva()
        {
            return View();
        }

        public ActionResult RetornaUsuario(string apellido1, string nombre)
        {
            List<sp_RetornaUsuarios_Result> usuario =
               this.modeloBD.sp_RetornaUsuarios("", "").ToList();
            return Json(usuario);
        }
        public ActionResult RetornaVehiculo(string placa)
        {
            List<sp_RetornaVehiculos_Result> vehiculo =
               this.modeloBD.sp_RetornaVehiculos("").ToList();
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


        ///// <summary>
        ///// metodo que Retorna Servicio o producto
        ///// /// </summary>
        ////<returns></returns>
        public ActionResult RetornaServioPro(string descripcion, string tipo)
        {
            List<sp_RetornaServicioOProducto_Result> servicio =
               this.modeloBD.sp_RetornaServicioOProducto( descripcion, null).ToList();
            return Json(servicio);
        }
        public ActionResult RetornaEncabezado()
        {
            List<sp_RetornaFacturaEnc_Result> encabezado =
               this.modeloBD.sp_RetornaFacturaEnc("").ToList();
            return Json(encabezado);

        }

        /// <summary>
        /// metodo que Inserta una Empresa
        /// /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult InsertaDetalleFa(
        int  pIdServProduc,
        int pCantidadSoP,
        decimal pPrecioTotal,
        int pIdEncabezadoFac
        )
        {
            /// variable que registra la cantidad de registros afectados
            ///si un procedimiento que se ejecuta insert,update,delete
            ///no afecta registros implica que hubo un error



            int cantidadRegistroAfectados = 0;
            string resultado = " ";



            try
            {
                cantidadRegistroAfectados =
                this.modeloBD.sp_InsertaDetalleFac(
                pIdServProduc,
                pCantidadSoP,
                pPrecioTotal,
                pIdEncabezadoFac
               
                );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;



            }
            finally
            {
                if (cantidadRegistroAfectados > 0)
                {
                    resultado = " El Registro Se Inserto Correctamente";
                }
                else
                {
                    resultado += ".No se pudo Insertar ";
                }
            }
          
            return Json(resultado);
        }

    }

  }



