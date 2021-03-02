using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class MarcaVehiculoController : Controller
    {
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        public ActionResult MarcaVehiculoLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaMarcaVehiculo_Result> modeloVista =
                new List<sp_RetornaMarcaVehiculo_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaMarcaVehiculo("","").ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }
        /// <summary>
        /// controlador que me insetar una nueva marca vehiculo
        /// </summary>
        /// <returns></returns>
        public ActionResult MarcaVehiculoNueva()
        {
            this.AgregaPaisFabricacionViewBag();
            return View();
        }
        /// <summary>
        /// Agrega el pais al viewbag para que sean
        /// accedidas desede la vista
        /// ES CASE SENSITIVE
        /// </summary>
        void AgregaPaisFabricacionViewBag()
        {
            this.ViewBag.ListaPais =
             this.modeloBD.sp_RetornaPaísFabricante(null,null).ToList();

        }
        /// insert MarcabVehiculo Nueva tipo httpPost
        [HttpPost]
        public ActionResult MarcaVehiculoNueva(sp_RetornaMarcaVehiculo_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertarMarcaVehiculos(
                        modeloVista.Codigo,
                        modeloVista.Tipo,
                        modeloVista.idPaisFabricante

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

            this.AgregaPaisFabricacionViewBag();
            return View();
        }

        /// <summary>
        /// controlador que ELIMINA una Marca Vehiculo
        /// </summary>
        /// <param name="idMarcaVehiculo"></param>
        /// <returns></returns>
        public ActionResult MarcaVehiculoElimina(int idMarcaVehiculos)
        {
            ///obtener el registro que se debe eliminar
            ///utilizando el parametro idMarcaVehiculo
            sp_RetornaMarcaVehiculo_ID_Result modeloVista = new sp_RetornaMarcaVehiculo_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaMarcaVehiculo_ID(idMarcaVehiculos).FirstOrDefault();

            //se agregan Pias fabricacion 
            this.AgregaPaisFabricacionViewBag();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// ELIMINA MarcaVehiculo tipo httpPost
        [HttpPost]
        public ActionResult MarcaVehiculoElimina(sp_RetornaMarcaVehiculo_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_EliminarMarcaVehiculo(modeloVista.idMarcaVehiculos);

            }
            catch (Exception error)
            {

                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)

                    resultado = "Registro Eliminado Correctamente";

                else
                    resultado = "No se pudo Eliminar el Registro";

            }

            this.AgregaPaisFabricacionViewBag();
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }
    }
}