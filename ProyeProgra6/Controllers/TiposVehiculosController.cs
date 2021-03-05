using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class TiposVehiculosController : Controller
    {
        

        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        public ActionResult TiposVehiculosLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaTiposVehiculos_Result> modeloVista =
                new List<sp_RetornaTiposVehiculos_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaTiposVehiculos("","").ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }
        /// <summary>
        /// controlador que me INSERTA los tipos de vehiculos
        /// </summary>
        /// <returns></returns>
        public ActionResult TipoVehiculoNuevo()
        {
            return View();
        }


        /// insert tipo VEhiculo tipo httpPost
        [HttpPost]
        public ActionResult TipoVehiculoNuevo(sp_RetornaTiposVehiculos_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertaTiposVehiculos(
                        modeloVista.Codigo,
                        modeloVista.Tipo

                        );
            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado correctamente";
                }
                else
                {
                    resultado = "No se pudo insertar";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");


            return View();
        }
        /// <summary>
        ///  controlador que MODIFICA un tipo De Vehiculo
        /// </summary>
        /// <param name="idTipoVehiculo"></param>
        /// <returns></returns>
        public ActionResult ModificaTipoVehiculo(int idTipoVehiculo)
        {
            ///obtener el registro que se debe modificar
            ///utilizando el parametro
            sp_RetornaTiposVehiculos_ID_Result modeloVista = new sp_RetornaTiposVehiculos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaTiposVehiculos_ID(idTipoVehiculo).FirstOrDefault();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// Modifica Tipo VEhiculo tipo httpPost
        [HttpPost]
        public ActionResult ModificaTipoVehiculo(sp_RetornaTiposVehiculos_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_ModificaTiposVehiculos(
                        modeloVista.idTipoVehiculo,
                        modeloVista.Codigo,
                        modeloVista.Tipo
                        );
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error:" + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado";

                }
                else
                {
                    resultado += ".No se Pudo insertar";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            return View(modeloVista);
        }
        /// <summary>
        /// controlador que ELIMINA un Tipo VEhiculo
        /// </summary>
        /// <param name="idTipoVehiculo"></param>
        /// <returns></returns>
        public ActionResult TipoVehiculoElimina(int idTipoVehiculo)
        {
            ///obtener el registro que se debe eliminar
            ///utilizando el parametro 
            sp_RetornaTiposVehiculos_ID_Result modeloVista = new sp_RetornaTiposVehiculos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaTiposVehiculos_ID(idTipoVehiculo).FirstOrDefault();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// ELIMINA Tipo VEhiculo tipo httpPost
        [HttpPost]
        public ActionResult TipoVehiculoElimina(sp_RetornaTiposVehiculos_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_EliminaTipoVehiculos(modeloVista.idTipoVehiculo);

            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro Eliminado Correctamente";

                }
                else
                {
                    resultado = "No se pudo Eliminar el Registro";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }
    }
}
