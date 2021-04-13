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
        void AgregaUsuariosViewBag()
        {
            this.ViewBag.ListaUsuarios =
                    this.modeloBD.sp_RetornaUsuarios("","").ToList();
        }

        void AgregaPlacaViewBag()
        {
            this.ViewBag.ListaPlaca =
                    this.modeloBD.sp_RetornaVehiculos("").ToList();

        }
        public ActionResult FacturaNueva()
        {
            return View();
        }

        public ActionResult RetornaUsuario()
        {
            List<sp_RetornaUsuarios_Result> usuario =
               this.modeloBD.sp_RetornaUsuarios("", "").ToList();
            return Json(usuario);
        }
        public ActionResult RetornaVehiculo()
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
        // --------------------------------------------------------------------------------------------

        ///// <summary>
        /////  metodo o controlador que MODIFICA  
        /// </summary>
        /// <param name="idEncabezadoFac"></param>
        /// <returns></returns>

        public ActionResult EncabezadoFacModifica(int idEncabezadoFac)
        {
            //    ///obtener el registro que se debe modificar
            //    ///utilizando el parametro 
            sp_RetornaFacturaEnc_ID_Result modeloVista = new sp_RetornaFacturaEnc_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaFacturaEnc_ID(idEncabezadoFac).FirstOrDefault();
            this.AgregaPlacaViewBag();
            this.AgregaUsuariosViewBag();
            //    //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// Modifica factura tipo httpPost
        [HttpPost]
        public ActionResult EncabezadoFacModifica(sp_RetornaFacturaEnc_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_ModificaFacturaEnc(
                        modeloVista.idEncabezadoFac,
                        modeloVista.idUsuario,
                        modeloVista.idVehiculo,
                        modeloVista.Fecha,
                        modeloVista.MontoTotalServicio,
                        modeloVista.EstadoFactura

                        );
            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)

                    resultado = "Registro Modificado Correctamente";

                else
                    resultado = "No se pudo Modificar el Dato";

            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            this.AgregaPlacaViewBag();
            this.AgregaUsuariosViewBag();
            return View(modeloVista);
        }

        //----------------------------------------------------------------------------------------------------------------

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
        //-------------------------------------------------------------------------------------------
        /// <summary>
        /// metodo que Isertar  detalle factura
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



