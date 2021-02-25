using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class VehiculosController : Controller
    {
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();

        public ActionResult VehiculosLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaVehiculos_Result> modeloVista =
                new List<sp_RetornaVehiculos_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaVehiculos("").ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }
        /// <summary>
        /// controlador que meINSERTA un nuevo Vehiculo
        /// </summary>
        /// <returns></returns>
        public ActionResult VehiculoNuevo()
        {
            this.AgregaMarcaVehiculoViewBag();
            this.AgregaTipoVehiculoViewBag();
            return View();
        }
        /// <summary>
        /// Agrega las provincias al viewbag para que sean
        /// accedidas desede la vista
        /// ES CASE SENSITIVE
        /// </summary>
        void AgregaMarcaVehiculoViewBag()
        {
            this.ViewBag.ListaMarca =
             this.modeloBD.sp_RetornaMarcaVehiculo("").ToList();

        }
        void AgregaTipoVehiculoViewBag()
        {
            this.ViewBag.ListaTipos =
             this.modeloBD.sp_RetornaTiposVehiculos("").ToList();

        }

        /// insert Vehiculo tipo httpPost
        [HttpPost]
        public ActionResult VehiculoNuevo(sp_RetornaVehiculos_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_InsertaVehiculos(
                        modeloVista.Placa,
                        modeloVista.NumeroPuertas,
                        modeloVista.NumeroRuedas,
                        modeloVista.idMarcaVehiculos,
                        modeloVista.idTipoVehiculo
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

            this.AgregaMarcaVehiculoViewBag();
            this.AgregaTipoVehiculoViewBag();
            return View();
        }
    }
}