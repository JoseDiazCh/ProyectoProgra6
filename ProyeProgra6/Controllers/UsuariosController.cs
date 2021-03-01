﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyeProgra6.Models;

namespace ProyeProgra6.Controllers
{
    public class UsuariosController : Controller
    {
        
        proyectoprogra6Entities modeloBD = new proyectoprogra6Entities();


        /// <summary>
        /// Controlador que me LISTA las personas
        /// </summary>
        /// <returns></returns>
        public ActionResult UsuariosLista()
        {
            //creamos la variable que contiene los registros obtenidos
            ///al invocar los procesos almacenados
            List<sp_RetornaUsuarios_Result> modeloVista =
                new List<sp_RetornaUsuarios_Result>();

            ///asignar a la variable el resultado de 'llamas el procedimiento almacenado

            modeloVista = this.modeloBD.sp_RetornaUsuarios(null, null).ToList();
            //enviar a la vista el modelo
            return View(modeloVista);

        }
        ////--------------------------------------------------------------------------------------------

        /// <summary>
        /// retorna todas las provincias
        /// </summary>
        /// <returns></returns>
        public ActionResult RetornaProvincias()
        {
            List<sp_RetornaProvincias_Result> provincias =
                this.modeloBD.sp_RetornaProvincias(null).ToList();
            return Json(provincias);
        }
        /// <summary>
        ///  Metodo que retorna todos los cantones cuando se selecciona una provincia
        /// </summary>
        /// <param name="id_Provincias"></param>
        /// <returns></returns>
        public ActionResult RetornaCantones(int id_Provincia)
        {
            List<sp_RetornaCantones_Result> cantones =
                this.modeloBD.sp_RetornaCantones(null, id_Provincia).ToList();
            return Json(cantones);
        }

        /// <summary>
        ///  Metodo queretorna todos los cantones cuando se selecciona una provincia
        /// </summary>
        /// <param name="id_Canton"></param>
        /// <returns></returns>
        public ActionResult RetornaDistritos(int id_Canton)
        {
            List<sp_RetornaDistritos_Result> distritos =
                this.modeloBD.sp_RetornaDistritos(" ", id_Canton).ToList();
            return Json(distritos);
        }

        //------------------------------------------------------------------------------------//
        /// <summary>
        /// INSERTA la nueva persona
        /// </summary>
        /// <returns></returns>

        public ActionResult UsuarioNuevo()
        {
            //AgregaProvinciasViewBag();
            //AgregaCantonesViewBag();
            //AgregaDistritosViewgBag();


            return View();
        }

        /// //agrega provincias al viewbag
        /// <summary>
        /// para que sean accedidas desde la vista
        /// es case sensitive
        /// </summary>

        //void AgregaProvinciasViewBag()
        //{
        //    this.ViewBag.ListaProvincias =
        //            this.modeloBD.sp_RetornaProvincias("").ToList();
        //}

        //void AgregaCantonesViewBag()
        //{
        //    this.ViewBag.ListaCantones =
        //            this.modeloBD.sp_RetornaCantones("",null).ToList();
        
        //}

        //void AgregaDistritosViewgBag()
        //{
        //    this.ViewBag.ListaDistritos =
        //        this.modeloBD.sp_RetornaDistritos("", null);
        //}
        /// <summary>
        /// este INSERTA la persona nueva tipo HttpPost
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UsuarioNuevo(sp_RetornaUsuarios_Result modeloVista)
        {
            ///registra cantidad de registros afectados.
            ///
            int cantRegistrosafectados = 0;
            string resultado = "";

            try
            {
                
                cantRegistrosafectados =
                    this.modeloBD.sp_InsertaUsuarios(
                        modeloVista.Cedula,
                        modeloVista.Genero,
                        modeloVista.FechaNacimiento,
                        modeloVista.Nombre,
                        modeloVista.Apellido1,
                        modeloVista.Apellido2,
                        modeloVista.Correo,
                        modeloVista.TipoUsuario ,
                        modeloVista.id_Provincia,
                        modeloVista.id_Canton,
                        modeloVista.id_Distrito,
                        modeloVista.Contrasenia
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
            //this.AgregaProvinciasViewBag();
            //this.AgregaCantonesViewBag();
            //this.AgregaDistritosViewgBag();

            
            return View();
        }
        //-----------------------------------------------------------------------------------
       
        ///------------------------------------------------------------------------------


    }
}