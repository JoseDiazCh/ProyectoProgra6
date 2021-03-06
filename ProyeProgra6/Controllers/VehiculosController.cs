﻿using System;
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
        /// controlador que me INSERTA un nuevo Vehiculo
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
             this.modeloBD.sp_RetornaMarcaVehiculo(null,"").ToList();

        }
        void AgregaTipoVehiculoViewBag()
        {
            this.ViewBag.ListaTipos =
             this.modeloBD.sp_RetornaTiposVehiculos(null,"").ToList();

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

        public ActionResult ModificaVehiculo(int idVehiculo)
        {
            ///obtener el registro que se debe modificar
            ///utilizando el parametro
            sp_RetornaVehiculos_ID_Result modeloVista = new sp_RetornaVehiculos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaVehiculos_ID(idVehiculo).FirstOrDefault();
            this.AgregaMarcaVehiculoViewBag();
            this.AgregaTipoVehiculoViewBag();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// Modifica Usuario tipo httpPost
        [HttpPost]
        public ActionResult ModificaVehiculo(sp_RetornaVehiculos_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                        this.modeloBD.sp_ModificaVehiculo(
                            modeloVista.idVehiculo,
                            modeloVista.Placa,
                            modeloVista.NumeroPuertas,
                            modeloVista.NumeroRuedas,
                            modeloVista.idMarcaVehiculos,
                            modeloVista.idTipoVehiculo
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
                    resultado = "Registro modificado";

                }
                else
                {
                    resultado += ".No se pudo modificar";
                }
            }
            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            this.AgregaMarcaVehiculoViewBag();
            this.AgregaTipoVehiculoViewBag();
            return View(modeloVista);
        }
        /// <summary>
        /// Controlador que elimina el usuario
        /// </summary>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public ActionResult EliminaVehiculo(int idVehiculo)
        {
            ///obtener el registro que se debe modificar
            ///utilizando el parametro
            sp_RetornaVehiculos_ID_Result modeloVista = new sp_RetornaVehiculos_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaVehiculos_ID(idVehiculo).FirstOrDefault();
            this.AgregaMarcaVehiculoViewBag();
            this.AgregaTipoVehiculoViewBag();

            //enviar el modelo a la vista
            return View(modeloVista);
        }
        /// ELIMINA Usuario tipo httpPost
        [HttpPost]
        public ActionResult EliminaVehiculo(sp_RetornaVehiculos_ID_Result modeloVista)
        {
            ///registra la cantidad de  registros afectados
            ///si un prrocedimiento se ejecuta INSERT, UPDATE, DELETE
            ///no afecta registros implica que hubo un error

            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.modeloBD.sp_EliminarVehiculo(modeloVista.idVehiculo);

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
            this.AgregaMarcaVehiculoViewBag();
            this.AgregaTipoVehiculoViewBag();
            return View(modeloVista);
        }

    }
}
